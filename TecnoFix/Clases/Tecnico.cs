namespace TecnoFix.Clases
{
    //Tabla Tecnico
    public class Tecnico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public Tecnico Copiar() { return (Tecnico)this.MemberwiseClone(); }
    }
}
