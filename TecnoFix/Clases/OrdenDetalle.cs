using System;

namespace TecnoFix.Clases
{
    //lo q se muestra en el datagrid
    //(Orden + datos del cliente, equipo, estado y tecnico). El orden = orden de columnas.
    public class OrdenDetalle
    {
        public int Id { get; set; }
        public int IdEquipo { get; set; }
        public int IdCliente { get; set; }
        public int? IdTecnico { get; set; }
        public int IdEstado { get; set; }
        public string Cliente { get; set; }
        public string Telefono { get; set; }
        public string Equipo { get; set; }
        public string Serie { get; set; }
        public string Falla { get; set; }
        public string Diagnostico { get; set; }
        public string Estado { get; set; }
        public string Tecnico { get; set; }
        public string RegistradoPor { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaEntrega { get; set; }
    }
}
