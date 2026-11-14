using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TecnoFix.Clases;
using TecnoFix.Repositorios;

namespace TecnoFix.Formularios
{
    public partial class frmTecnicos : Form
    {
        private TecnicoRepositorio repo = new TecnicoRepositorio();
        private Tecnico tecnicoActual = null; // null = nuevo tecnico

        public frmTecnicos()
        {
            InitializeComponent();

            // Eventos (no deben estar tambien en el Designer)
            this.Load += frmTecnicos_Load;
            this.FormClosed += frmTecnicos_FormClosed;
            txtNombre.KeyPress += txtNombre_KeyPress;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            btnGuardar.Click += btnGuardar_Click;
            btnNuevo.Click += btnNuevo_Click;
            btnEliminar.Click += btnEliminar_Click;
            dgvTecnicos.CellDoubleClick += dgvTecnicos_CellDoubleClick;
        }

        private void frmTecnicos_Load(object sender, EventArgs e)
        {
            Notificador.DatosCambiaron += CargarGrid;
            CargarUsuarios();
            CargarGrid();
        }

        private void frmTecnicos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Notificador.DatosCambiaron -= CargarGrid;
        }

        // Llena el combo con los usuarios de rol Tecnico que no estan ligados a otro tecnico
        private void CargarUsuarios()
        {
            List<Tecnico> tecnicos = repo.ObtenerTodos().ToList();
            List<ItemCombo> lista = new List<ItemCombo> { new ItemCombo { Id = 0, Texto = "Sin usuario" } };

            lista.AddRange(new UsuarioRepositorio().ObtenerTodos()
                .Where(u => u.Rol == "Tecnico" &&
                            !tecnicos.Any(t => t.IdUsuario == u.Id && (tecnicoActual == null || t.Id != tecnicoActual.Id)))
                .Select(u => new ItemCombo { Id = u.Id, Texto = u.NombreUser }));

            cboUsuario.DisplayMember = "Texto";
            cboUsuario.ValueMember = "Id";
            cboUsuario.DataSource = lista;
        }

        private void CargarGrid()
        {
            List<Usuario> usuarios = new UsuarioRepositorio().ObtenerTodos().ToList();

            dgvTecnicos.DataSource = (from t in repo.ObtenerTodos()
                                      join u in usuarios on t.IdUsuario equals u.Id into gu
                                      from u in gu.DefaultIfEmpty()
                                      orderby t.Id descending
                                      select new
                                      {
                                          Id = t.Id,
                                          Nombre = t.Nombre,
                                          Telefono = t.Telefono,
                                          Usuario = u == null ? "Sin usuario" : u.NombreUser
                                      }).ToList();

            dgvTecnicos.Columns["Id"].Visible = false;
            dgvTecnicos.Columns["Nombre"].HeaderText = "Nombre";
            dgvTecnicos.Columns["Telefono"].HeaderText = "Telefono";
            dgvTecnicos.Columns["Usuario"].HeaderText = "Usuario de acceso";
            dgvTecnicos.ReadOnly = true;
            dgvTecnicos.AllowUserToAddRows = false;
            dgvTecnicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTecnicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Limpiar()
        {
            tecnicoActual = null;
            txtNombre.Clear();
            txtTelefono.Clear();
            CargarUsuarios();
            btnGuardar.Text = "Guardar";
            txtNombre.Focus();
        }

        // Solo letras
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Solo numeros
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // La grilla ya no tiene objetos Tecnico, se busca el tecnico por su Id
        private void dgvTecnicos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = (int)dgvTecnicos.Rows[e.RowIndex].Cells["Id"].Value;
            Tecnico encontrado = repo.ObtenerPorId(id);
            if (encontrado == null) return;

            tecnicoActual = encontrado.Copiar();
            CargarUsuarios();   // incluye el usuario que ya tiene este tecnico
            txtNombre.Text = tecnicoActual.Nombre;
            txtTelefono.Text = tecnicoActual.Telefono;
            cboUsuario.SelectedValue = tecnicoActual.IdUsuario ?? 0;
            btnGuardar.Text = "Actualizar";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            if (nombre == "")
            {
                MessageBox.Show("El nombre es obligatorio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            // Telefono opcional: si se escribe, 8 digitos
            if (telefono != "" && (telefono.Length != 8 || !telefono.All(char.IsDigit)))
            {
                MessageBox.Show("El telefono debe tener 8 digitos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            // Si no hay telefono se guarda NULL en la base de datos
            string telefonoGuardar = telefono == "" ? null : telefono;

            // Usuario elegido en el combo (0 = sin usuario = NULL)
            int idUsuario = cboUsuario.SelectedValue == null ? 0 : (int)cboUsuario.SelectedValue;
            int? idUsuarioGuardar = idUsuario == 0 ? (int?)null : idUsuario;

            try
            {
                if (tecnicoActual == null)
                {
                    Tecnico nuevo = new Tecnico();
                    nuevo.Nombre = nombre;
                    nuevo.Telefono = telefonoGuardar;
                    nuevo.IdUsuario = idUsuarioGuardar;
                    repo.Insertar(nuevo);
                    MessageBox.Show("Tecnico guardado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    tecnicoActual.Nombre = nombre;
                    tecnicoActual.Telefono = telefonoGuardar;
                    tecnicoActual.IdUsuario = idUsuarioGuardar;
                    repo.Actualizar(tecnicoActual);
                    MessageBox.Show("Tecnico actualizado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Limpiar();
                CargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!Sesion.EsAdministrador)
            {
                MessageBox.Show("Solo el administrador puede eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tecnicoActual == null)
            {
                MessageBox.Show("Haga doble clic en un tecnico de la lista para seleccionarlo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult r = MessageBox.Show("Desea eliminar a " + tecnicoActual.Nombre + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                repo.Eliminar(tecnicoActual);
                Limpiar();
                CargarGrid();
            }
            catch (Exception)
            {
                // Falla por llave foranea: el tecnico tiene ordenes
                MessageBox.Show("No se puede eliminar: el tecnico tiene ordenes asociadas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}