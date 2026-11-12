namespace TecnoFix.Clases
{
    //muestra el datagrid de equipos (equipo + nombre del cliente)
    public class EquipoDetalle
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
    }
}
