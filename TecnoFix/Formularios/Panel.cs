using System;
using System.Windows.Forms;
using TecnoFix.Clases;
using TecnoFix.Repositorios;

namespace TecnoFix.Formularios
{
    public partial class Panel : Form
    {
        public Panel()
        {
            InitializeComponent();
        }

        private void Panel_Load(object sender, EventArgs e)
        {
            if (Sesion.HayUsuario)
            {
                string texto = "Usuario: " + Sesion.Actual.NombreUser + "   |   Rol: " + Sesion.Actual.Rol;
                //Si el usuario esta ligado a un tecnico, se muestra su nombre
                Tecnico tecnico = new TecnicoRepositorio().ObtenerPorUsuario(Sesion.Actual.Id);
                if (tecnico != null) texto += "   |   Tecnico: " + tecnico.Nombre;
                lblUsuario.Text = texto;
            }

            //El tecnico solo trabaja con clientes, equipos y ordenes
            tecnicosToolStripMenuItem.Enabled = Sesion.EsAdministrador;
            usuariosToolStripMenuItem.Enabled = Sesion.EsAdministrador;
            reportesToolStripMenuItem.Enabled = Sesion.EsAdministrador;
        }

        private void CerrarFormularioActivo()
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
        }

        //Aviso temporal para los modulos que faltan
        private void EnDesarrollo(string modulo)
        {
            MessageBox.Show("El modulo de " + modulo + " esta en desarrollo.", "TecnoFix",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AbrirFormulario(Form frm)
        {
            CerrarFormularioActivo();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        //Menu
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmClientes());
        }

        private void equiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmEquipos());
        }

        private void ordenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmOrdenes());
        }

        private void tecnicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnDesarrollo("Tecnicos");
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmUsuarios());
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnDesarrollo("Reportes");
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sesion.Cerrar();   //Program.cs vuelve a mostrar el login
            Close();
        }
    }
}
