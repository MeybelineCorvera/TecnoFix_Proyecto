using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TecnoFix.Clases;
using TecnoFix.Repositorios;

namespace TecnoFix.Formularios
{
    //Nueva orden, asignar tecnico y cambiar estado. Mismo patron que frmClientes:"seleccionado" == null -> orden nueva; != null -> se esta editando.
    public partial class frmOrdenes : Form
    {
        private readonly OrdenServicioRepositorio repo = new OrdenServicioRepositorio();
        private readonly EquipoRepositorio repoEquipos = new EquipoRepositorio();
        private OrdenServicio seleccionado = null;
        private bool cargando = true;   //evita que los combos disparen eventos mientras se llenan

        public frmOrdenes()
        {
            InitializeComponent();
        }

        private void frmOrdenes_Load(object sender, EventArgs e)
        {
            Notificador.DatosCambiaron += CargarGrid;
            btnEliminar.Enabled = Sesion.EsAdministrador;

            //Clientes
            cboCliente.DisplayMember = "Texto";
            cboCliente.ValueMember = "Id";
            cboCliente.DataSource = new ClienteRepositorio().ObtenerTodos()
                .Select(c => new ItemCombo { Id = c.Id, Texto = c.NombreCompleto + " - " + c.Telefono }).ToList();

            //Tecnicos (Id 0 = sin asignar)
            List<ItemCombo> tecnicos = new List<ItemCombo> { new ItemCombo { Id = 0, Texto = "Sin asignar" } };
            tecnicos.AddRange(new TecnicoRepositorio().ObtenerTodos()
                .Select(t => new ItemCombo { Id = t.Id, Texto = t.Nombre }));
            cboTecnico.DisplayMember = "Texto";
            cboTecnico.ValueMember = "Id";
            cboTecnico.DataSource = tecnicos;

            //Estados
            List<Estado> estados = new EstadoRepositorio().ObtenerTodos();
            cboEstado.DisplayMember = "Nombre";
            cboEstado.ValueMember = "Id";
            cboEstado.DataSource = estados.ToList();

            //Filtro (Id 0 = todos)
            List<ItemCombo> filtro = new List<ItemCombo> { new ItemCombo { Id = 0, Texto = "Todos" } };
            filtro.AddRange(estados.Select(s => new ItemCombo { Id = s.Id, Texto = s.Nombre }));
            cboFiltro.DisplayMember = "Texto";
            cboFiltro.ValueMember = "Id";
            cboFiltro.DataSource = filtro;

            cargando = false;
            LimpiarCampos();
            CargarGrid();
        }

        private void frmOrdenes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Notificador.DatosCambiaron -= CargarGrid;
        }

        //Combos
        // Al elegir un cliente se llenan solo sus equipos
        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            CargarEquiposDelCliente();
        }

        private void CargarEquiposDelCliente()
        {
            if (cboCliente.SelectedValue == null)
            {
                cboEquipo.DataSource = null;
                return;
            }

            int idCliente = (int)cboCliente.SelectedValue;
            cboEquipo.DisplayMember = "Texto";
            cboEquipo.ValueMember = "Id";
            cboEquipo.DataSource = repoEquipos.ObtenerPorCliente(idCliente)
                .Select(q => new ItemCombo
                {
                    Id = q.Id,
                    Texto = q.Tipo + " " + q.Marca + " " + q.Modelo +
                            (string.IsNullOrEmpty(q.Serie) ? "" : " (" + q.Serie + ")")
                }).ToList();
        }

        private void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            CargarGrid();
        }

        //datagrid
        private void CargarGrid()
        {
            List<OrdenDetalle> lista = repo.ObtenerDetalle();

            int idFiltro = cboFiltro.SelectedValue == null ? 0 : (int)cboFiltro.SelectedValue;
            if (idFiltro != 0) lista = lista.Where(o => o.IdEstado == idFiltro).ToList();

            dgvOrdenes.DataSource = lista;
            GridHelper.ConfigurarOrdenes(dgvOrdenes);
        }

        private void dgvOrdenes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            OrdenDetalle fila = (OrdenDetalle)dgvOrdenes.Rows[e.RowIndex].DataBoundItem;
            seleccionado = repo.ObtenerPorId(fila.Id);
            if (seleccionado == null) return;

            cboCliente.SelectedValue = fila.IdCliente;
            CargarEquiposDelCliente();
            cboEquipo.SelectedValue = seleccionado.IdEquipo;
            cboTecnico.SelectedValue = seleccionado.IdTecnico ?? 0;
            cboEstado.SelectedValue = seleccionado.IdEstado;
            txtFalla.Text = seleccionado.Falla;
            txtDiagnostico.Text = seleccionado.Diagnostico;

            //El cliente y el equipo no se cambian en una orden existente (evita mezclar equipos)
            cboCliente.Enabled = false;
            cboEquipo.Enabled = false;
            btnGuardar.Text = "Actualizar";
        }

        //Buttons
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string falla = txtFalla.Text.Trim();
            string diagnostico = txtDiagnostico.Text.Trim();

            if (cboCliente.SelectedValue == null || cboEquipo.SelectedValue == null)
            {
                Aviso("Seleccione el cliente y el equipo. Si el cliente no tiene equipos, registrelos primero en Equipos.");
                return;
            }
            if (falla == "")
            {
                Aviso("Describa la falla reportada por el cliente.");
                txtFalla.Focus();
                return;
            }

            int idEstado = (int)cboEstado.SelectedValue;
            int idTecnico = (int)cboTecnico.SelectedValue;

            //una orden no avanza de "Recibido" sin tecnico responsable
            if (idEstado != EstadoOrden.Recibido && idTecnico == 0)
            {
                Aviso("Asigne un tecnico antes de pasar la orden a otro estado.");
                cboTecnico.Focus();
                return;
            }

            try
            {
                if (seleccionado == null)
                {
                    repo.Insertar(new OrdenServicio
                    {
                        IdEquipo = (int)cboEquipo.SelectedValue,
                        IdTecnico = idTecnico == 0 ? (int?)null : idTecnico,
                        IdEstado = idEstado,
                        FechaIngreso = DateTime.Now,   //obligatorioya q sin esto SQL rechaza la fecha 0001
                        Falla = falla,
                        Diagnostico = diagnostico == "" ? null : diagnostico,
                        FechaEntrega = idEstado == EstadoOrden.Entregado ? DateTime.Now : (DateTime?)null
                    });
                    MessageBox.Show("Orden registrada.", "TecnoFix",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    seleccionado.IdTecnico = idTecnico == 0 ? (int?)null : idTecnico;
                    seleccionado.IdEstado = idEstado;
                    seleccionado.Falla = falla;
                    seleccionado.Diagnostico = diagnostico == "" ? null : diagnostico;

                    if (idEstado == EstadoOrden.Entregado)
                    {
                        if (seleccionado.FechaEntrega == null) seleccionado.FechaEntrega = DateTime.Now;
                    }
                    else
                    {
                        seleccionado.FechaEntrega = null;   //si se devuelve a otro estado, ya no esta entregada
                    }

                    repo.Actualizar(seleccionado);
                    MessageBox.Show("Orden actualizada.", "TecnoFix",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (seleccionado == null)
            {
                Aviso("Haga doble clic en una orden de la lista para seleccionarla.");
                return;
            }

            DialogResult r = MessageBox.Show("Desea eliminar la orden #" + seleccionado.Id + "?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                repo.Eliminar(seleccionado);
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Utilidades
        private void LimpiarCampos()
        {
            seleccionado = null;
            cboCliente.Enabled = true;
            cboEquipo.Enabled = true;
            cboCliente.SelectedIndex = -1;
            cboEquipo.DataSource = null;
            cboTecnico.SelectedValue = 0;
            cboEstado.SelectedValue = EstadoOrden.Recibido;
            txtFalla.Clear();
            txtDiagnostico.Clear();
            btnGuardar.Text = "Guardar";
            cboCliente.Focus();
        }

        private void Aviso(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
