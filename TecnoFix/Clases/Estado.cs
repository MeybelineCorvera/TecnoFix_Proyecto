namespace TecnoFix.Clases
{
    //Tabla Estado el catalogo fijo de 6 estados
    public class Estado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    //Id de los estados
    public static class EstadoOrden
    {
        public const int Recibido = 1;
        public const int EnDiagnostico = 2;
        public const int EnEsperaDeRepuesto = 3;
        public const int EnReparacion = 4;
        public const int Finalizado = 5;
        public const int Entregado = 6;
    }
}
