using System;
using System.Net.Mail;
using System.Linq;
using System.Windows.Forms;
using TecnoFix.Clases;
using TecnoFix.Repositorios;

namespace TecnoFix.Formularios
{
    public partial class frmClientes : Form
    {
        private readonly ClienteRepositorio repo = new ClienteRepositorio();
        private Cliente seleccionado = null;

        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            Notificador.DatosCambiaron += CargarGrid;   //se actualiza solo al guardar
            btnEliminar.Enabled = Sesion.EsAdministrador;
            CargarGrid();
        }

        private void frmClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Notificador.DatosCambiaron -= CargarGrid;
        }

        //datagrid 
        private void CargarGrid()
        {
            dgvClientes.DataSource = repo.ObtenerTodos();

            dgvClientes.Columns["Id"].Visible = false;
            dgvClientes.Columns["NombreCompleto"].Visible = false;
            dgvClientes.Columns["Nombre"].HeaderText = "Nombre";
            dgvClientes.Columns["Apellido"].HeaderText = "Apellido";
            dgvClientes.Columns["Telefono"].HeaderText = "Telefono";
            dgvClientes.Columns["Correo"].HeaderText = "Correo";
            dgvClientes.ReadOnly = true;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Cliente fila = (Cliente)dgvClientes.Rows[e.RowIndex].DataBoundItem;
            seleccionado = fila.Copiar();

            txtNombre.Text = seleccionado.Nombre;
            txtApellido.Text = seleccionado.Apellido;
            txtTelefono.Text = seleccionado.Telefono;
            txtCorreo.Text = seleccionado.Correo;
            btnGuardar.Text = "Actualizar";
        }

        //Validacion de teclas (KeyPress) 
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; //Bloquea cualquier otra tecla
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; //Bloquea cualquier otra tecla
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; //Bloquea cualquier otra tecla
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        //Botones
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string correo = txtCorreo.Text.Trim();

            if (nombre == "" || apellido == "")
            {
                Aviso("El nombre y el apellido son obligatorios.");
                return;
            }
            if (telefono.Length != 8 || !telefono.All(char.IsDigit))
            {
                Aviso("El telefono debe tener exactamente 8 digitos.");
                txtTelefono.Focus();
                return;
            }
            if (correo != "" && !CorreoValido(correo))
            {
                Aviso("El correo no tiene un formato valido.");
                txtCorreo.Focus();
                return;
            }

            int idActual = seleccionado == null ? 0 : seleccionado.Id;
            if (repo.ExisteTelefono(telefono, idActual))
            {
                Aviso("Ya existe un cliente con ese telefono.");
                txtTelefono.Focus();
                return;
            }

            try
            {
                if (seleccionado == null)
                {
                    repo.Insertar(new Cliente
                    {
                        Nombre = nombre.ToUpper(),
                        Apellido = apellido.ToUpper(),
                        Telefono = telefono,
                        Correo = correo == "" ? null : correo
                    });
                    MessageBox.Show("Cliente guardado.", "TecnoFix",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    seleccionado.Nombre = nombre.ToUpper();
                    seleccionado.Apellido = apellido.ToUpper();
                    seleccionado.Telefono = telefono;
                    seleccionado.Correo = correo == "" ? null : correo;
                    repo.Actualizar(seleccionado);
                    MessageBox.Show("Cliente actualizado.", "TecnoFix",
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
                Aviso("Haga doble clic en un cliente de la lista para seleccionarlo.");
                return;
            }

            DialogResult r = MessageBox.Show(
                "Desea eliminar a " + seleccionado.NombreCompleto + "?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                repo.Eliminar(seleccionado);
                LimpiarCampos();
            }
            catch (Exception)
            {
                //Falla si el cliente tiene equipos registrados (llave foranea)
                MessageBox.Show("No se puede eliminar: el cliente tiene equipos u ordenes asociados.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Utilidades
        private void LimpiarCampos()
        {
            seleccionado = null;
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            btnGuardar.Text = "Guardar";
            txtNombre.Focus();
        }

        //Valida q el formato del correo (es opcional: si esta vacio no se llama)
        private bool CorreoValido(string correo)
        {
            try { return new MailAddress(correo).Address == correo; }
            catch { return false; }
        }

        private void Aviso(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
