using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TecnoFix.Clases;
using TecnoFix.Repositorios;

namespace TecnoFix.Formularios
{
    public partial class frmEquipos : Form
    {
        private readonly EquipoRepositorio repo = new EquipoRepositorio();
        private Equipo seleccionado = null;

        public frmEquipos()
        {
            InitializeComponent();
        }

        private void frmEquipos_Load(object sender, EventArgs e)
        {
            Notificador.DatosCambiaron += CargarGrid;
            btnEliminar.Enabled = Sesion.EsAdministrador;

            List<ItemCombo> clientes = new ClienteRepositorio().ObtenerTodos()
                .Select(c => new ItemCombo { Id = c.Id, Texto = c.NombreCompleto + " - " + c.Telefono })
                .ToList();
            cboCliente.DisplayMember = "Texto";
            cboCliente.ValueMember = "Id";
            cboCliente.DataSource = clientes;
            cboCliente.SelectedIndex = -1;
            cboTipo.SelectedIndex = -1;

            CargarGrid();
        }

        private void frmEquipos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Notificador.DatosCambiaron -= CargarGrid;
        }

        //datagrid
        private void CargarGrid()
        {
            dgvEquipos.DataSource = repo.ObtenerDetalle();

            dgvEquipos.Columns["Id"].Visible = false;
            dgvEquipos.Columns["IdCliente"].Visible = false;
            dgvEquipos.Columns["Cliente"].HeaderText = "Cliente";
            dgvEquipos.Columns["Tipo"].HeaderText = "Tipo";
            dgvEquipos.Columns["Marca"].HeaderText = "Marca";
            dgvEquipos.Columns["Modelo"].HeaderText = "Modelo";
            dgvEquipos.Columns["Serie"].HeaderText = "Serie";
            dgvEquipos.ReadOnly = true;
            dgvEquipos.AllowUserToAddRows = false;
            dgvEquipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEquipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvEquipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            EquipoDetalle fila = (EquipoDetalle)dgvEquipos.Rows[e.RowIndex].DataBoundItem;
            seleccionado = repo.ObtenerPorId(fila.Id);
            if (seleccionado == null) return;

            cboCliente.SelectedValue = seleccionado.IdCliente;
            cboTipo.SelectedIndex = cboTipo.FindStringExact(seleccionado.Tipo);
            txtMarca.Text = seleccionado.Marca;
            txtModelo.Text = seleccionado.Modelo;
            txtSerie.Text = seleccionado.Serie;
            btnGuardar.Text = "Actualizar";
        }

        //Validacion de teclas (KeyPress)
        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar)
                && e.KeyChar != ' ' && e.KeyChar != '-' && e.KeyChar != '/')
            {
                e.Handled = true; // Bloquea cualquier otra tecla
                MessageBox.Show("Solo se permiten letras, numeros, espacio, - y /", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar)
                && e.KeyChar != ' ' && e.KeyChar != '-' && e.KeyChar != '/')
            {
                e.Handled = true; //Bloquea cualquier otra tecla
                MessageBox.Show("Solo se permiten letras, numeros, espacio, - y /", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar)
                && e.KeyChar != ' ' && e.KeyChar != '-' && e.KeyChar != '/')
            {
                e.Handled = true; //Bloquea cualquier otra tecla
                MessageBox.Show("Solo se permiten letras, numeros, espacio, - y /", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // Botones
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string marca = txtMarca.Text.Trim();
            string modelo = txtModelo.Text.Trim();
            string serie = txtSerie.Text.Trim();

            if (cboCliente.SelectedIndex < 0)
            {
                Aviso("Seleccione el cliente dueno del equipo.");
                return;
            }
            if (cboTipo.SelectedIndex < 0)
            {
                Aviso("Seleccione el tipo de equipo.");
                return;
            }
            if (marca == "" || modelo == "")
            {
                Aviso("La marca y el modelo son obligatorios.");
                return;
            }

            int idActual = seleccionado == null ? 0 : seleccionado.Id;
            if (repo.ExisteSerie(serie.ToUpper(), idActual))
            {
                Aviso("Ya existe un equipo con esa serie.");
                txtSerie.Focus();
                return;
            }

            int idCliente = (int)cboCliente.SelectedValue;
            string tipo = cboTipo.Text;

            try
            {
                if (seleccionado == null)
                {
                    repo.Insertar(new Equipo
                    {
                        IdCliente = idCliente,
                        Tipo = tipo,
                        Marca = marca.ToUpper(),
                        Modelo = modelo.ToUpper(),
                        Serie = serie == "" ? null : serie.ToUpper()
                    });
                    MessageBox.Show("Equipo guardado.", "TecnoFix",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    seleccionado.IdCliente = idCliente;
                    seleccionado.Tipo = tipo;
                    seleccionado.Marca = marca.ToUpper();
                    seleccionado.Modelo = modelo.ToUpper();
                    seleccionado.Serie = serie == "" ? null : serie.ToUpper();
                    repo.Actualizar(seleccionado);
                    MessageBox.Show("Equipo actualizado.", "TecnoFix",
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
                Aviso("Haga doble clic en un equipo de la lista para seleccionarlo.");
                return;
            }

            DialogResult r = MessageBox.Show(
                "Desea eliminar el equipo " + seleccionado.Marca + " " + seleccionado.Modelo + "?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                repo.Eliminar(seleccionado);
                LimpiarCampos();
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede eliminar: el equipo tiene ordenes de servicio asociadas.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Utilidades
        private void LimpiarCampos()
        {
            seleccionado = null;
            cboCliente.SelectedIndex = -1;
            cboTipo.SelectedIndex = -1;
            txtMarca.Clear();
            txtModelo.Clear();
            txtSerie.Clear();
            btnGuardar.Text = "Guardar";
            cboCliente.Focus();
        }

        private void Aviso(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
