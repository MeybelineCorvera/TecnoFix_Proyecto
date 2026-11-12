namespace TecnoFix.Clases
{
    //se guarda al usuario que inicio sesion mientras la aplicacion esta abierta
    public static class Sesion
    {
        public static Usuario Actual { get; set; }

        public static bool HayUsuario { get { return Actual != null; } }
        public static bool EsAdministrador { get { return Actual != null && Actual.Rol == "Administrador"; } }

        public static void Cerrar() { Actual = null; }
    }
}
