using System;

namespace TecnoFix.Clases
{
    //Tabla OrdenServicio
    public class OrdenServicio
    {
        public int Id { get; set; }
        public int IdEquipo { get; set; }
        public int? IdTecnico { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Falla { get; set; }
        public string Diagnostico { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public int IdUsuario { get; set; }   //usuario que registro la orden
        public OrdenServicio Copiar() { return (OrdenServicio)this.MemberwiseClone(); }
    }
}
