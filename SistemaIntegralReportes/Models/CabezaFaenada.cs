namespace SistemaIntegralReportes.Models
{
    public class CabezaFaenada
    {
        public long IdInnova { get; set; }
        public long IdGecos { get; set; }
        public DateTime FechaFaena { get; set; }
        public string Proveedor { get; set; }
        public int Secuencial { get; set; }
        public string Caravana { get; set; }
        public string DotNumber { get; set; }
        public double PesoEnPie { get; set; }
        public double PesoMedia { get; set; }
        public DateTime FechaHoraEtiquetado { get; set; }
    }
}
