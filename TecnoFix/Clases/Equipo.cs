namespace TecnoFix.Clases
{
    //Tabla Equipo
    public class Equipo
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }

        public Equipo Copiar() { return (Equipo)this.MemberwiseClone(); }
    }
}
