namespace TecnoFix.Clases
{
    //Tabla Usuario
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUser { get; set; }
        public string Clave { get; set; }   //hash SHA-256, nunca la clave real
        public string Rol { get; set; }     //"Administrador" o "Tecnico"

        public Usuario Copiar() { return (Usuario)this.MemberwiseClone(); }
    }
}
