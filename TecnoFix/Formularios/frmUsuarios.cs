using System;
using System.Windows.Forms;
using TecnoFix.Clases;
using TecnoFix.Repositorios;

namespace TecnoFix.Formularios
{
    //Solo el administrador entra aqui (el Panel bloquea el menu para el tecnico).
    public partial class frmUsuarios : Form
    {
        private readonly UsuarioRepositorio repo = new UsuarioRepositorio();
        private Usuario seleccionado = null;

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            Notificador.DatosCambiaron += CargarGrid;
            cboRol.SelectedIndex = -1;
            CargarGrid();
        }

        private void frmUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            Notificador.DatosCambiaron -= CargarGrid;
        }

        private void CargarGrid()
        {
            dgvUsuarios.DataSource = repo.ObtenerTodos();

            dgvUsuarios.Columns["Id"].Visible = false;
            dgvUsuarios.Columns["Clave"].Visible = false;
            dgvUsuarios.Columns["NombreUser"].HeaderText = "Usuario";
            dgvUsuarios.Columns["Rol"].HeaderText = "Rol";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Usuario fila = (Usuario)dgvUsuarios.Rows[e.RowIndex].DataBoundItem;
            seleccionado = fila.Copiar();

            txtUsuario.Text = seleccionado.NombreUser;
            txtClave.Clear();
            cboRol.SelectedIndex = cboRol.FindStringExact(seleccionado.Rol);
            btnGuardar.Text = "Actualizar";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text;

            if (usuario.Length < 4)
            {
                Aviso("El usuario debe tener al menos 4 caracteres.");
                txtUsuario.Focus();
                return;
            }
            if (cboRol.SelectedIndex < 0)
            {
                Aviso("Seleccione el rol.");
                return;
            }
            //Clave obligatoria al crear, al editar solo si se quiere cambiar
            if ((seleccionado == null || clave != "") && clave.Length < 6)
            {
                Aviso("La clave debe tener al menos 6 caracteres.");
                txtClave.Focus();
                return;
            }

            int idActual = seleccionado == null ? 0 : seleccionado.Id;
            if (repo.ExisteUsuario(usuario, idActual))
            {
                Aviso("Ya existe un usuario con ese nombre.");
                txtUsuario.Focus();
                return;
            }

            //No se permitir que el administrador se quite su propio rol
            if (seleccionado != null && Sesion.Actual != null && seleccionado.Id == Sesion.Actual.Id
                && cboRol.Text != "Administrador")
            {
                Aviso("No puede quitarse a si mismo el rol de administrador.");
                return;
            }

            try
            {
                if (seleccionado == null)
                {
                    repo.Insertar(new Usuario
                    {
                        NombreUser = usuario,
                        Clave = Seguridad.CalcularHash(clave),
                        Rol = cboRol.Text
                    });
                    MessageBox.Show("Usuario guardado.", "TecnoFix",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    seleccionado.NombreUser = usuario;
                    seleccionado.Rol = cboRol.Text;
                    if (clave != "") seleccionado.Clave = Seguridad.CalcularHash(clave);
                    repo.Actualizar(seleccionado);
                    MessageBox.Show("Usuario actualizado.", "TecnoFix",
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
                Aviso("Haga doble clic en un usuario de la lista para seleccionarlo.");
                return;
            }
            if (Sesion.Actual != null && seleccionado.Id == Sesion.Actual.Id)
            {
                Aviso("No puede eliminar el usuario con el que inicio sesion.");
                return;
            }

            DialogResult r = MessageBox.Show("Desea eliminar al usuario " + seleccionado.NombreUser + "?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void LimpiarCampos()
        {
            seleccionado = null;
            txtUsuario.Clear();
            txtClave.Clear();
            cboRol.SelectedIndex = -1;
            btnGuardar.Text = "Guardar";
            txtUsuario.Focus();
        }

        private void Aviso(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
