using System;
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
            CargarGrid();
        }

        private void frmTecnicos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Notificador.DatosCambiaron -= CargarGrid;
        }

        private void CargarGrid()
        {
            dgvTecnicos.DataSource = repo.ObtenerTodos().ToList();
            if (dgvTecnicos.Columns["Id"] != null)
                dgvTecnicos.Columns["Id"].Visible = false;
            if (dgvTecnicos.Columns["IdUsuario"] != null)
                dgvTecnicos.Columns["IdUsuario"].Visible = false;
        }

        private void Limpiar()
        {
            tecnicoActual = null;
            txtNombre.Clear();
            txtTelefono.Clear();
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

        // Pasar el tecnico de la grilla a los campos
        private void dgvTecnicos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Tecnico fila = (Tecnico)dgvTecnicos.Rows[e.RowIndex].DataBoundItem;
            tecnicoActual = fila.Copiar();
            txtNombre.Text = tecnicoActual.Nombre;
            txtTelefono.Text = tecnicoActual.Telefono;
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

            try
            {
                if (tecnicoActual == null)
                {
                    Tecnico nuevo = new Tecnico();
                    nuevo.Nombre = nombre;
                    nuevo.Telefono = telefonoGuardar;
                    repo.Insertar(nuevo);
                    MessageBox.Show("Tecnico guardado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    tecnicoActual.Nombre = nombre;
                    tecnicoActual.Telefono = telefonoGuardar;
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