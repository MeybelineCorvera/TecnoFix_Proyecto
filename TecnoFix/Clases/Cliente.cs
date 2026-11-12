namespace TecnoFix.Clases
{
    //Tabla Cliente
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public string NombreCompleto { get { return Nombre + " " + Apellido; } }

        public Cliente Copiar() { return (Cliente)this.MemberwiseClone(); }
    }
}
