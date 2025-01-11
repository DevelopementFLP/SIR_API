namespace SistemaIntegralReportes.DTO.Carga
{
    public class DetalleCargaReporteDTO
    {
        public int IdReporte { get; set; }
        public int IdCarga { get; set; }
        public string Contenedor { get; set; }
        public double PesoBruto { get; set; }
    }
}
