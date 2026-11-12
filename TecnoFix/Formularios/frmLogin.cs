using System;
using System.Windows.Forms;
using TecnoFix.Clases;
using TecnoFix.Repositorios;

namespace TecnoFix.Formularios
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text;

            if (usuario == "" || clave == "")
            {
                MessageBox.Show("Escriba el usuario y la clave.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Usuario encontrado = new UsuarioRepositorio().Validar(usuario, clave);
                if (encontrado == null)
                {
                    MessageBox.Show("Usuario o clave incorrectos.", "Acceso denegado",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClave.Clear();
                    txtClave.Focus();
                    return;
                }

                Sesion.Actual = encontrado;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar a la base de datos.\n" +
                                "Revise la cadena de conexion en App.config.\n\n" + ex.Message,
                    "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
