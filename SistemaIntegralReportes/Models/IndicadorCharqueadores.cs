namespace SistemaIntegralReportes.Models
{
    public class IndicadorCharqueadores
    {
        public string? Linea { get; set; }
        public string? NombreEstacion { get; set; }
        public int IdEstacion { get; internal set; }
        public string CharqNum { get; set; }
        public string Charqueador { get; set; }
        public int CortesRecibidos { get; set; }
        public int CortesEnviados { get; set; }
        public double KgRecibidos { get; set; }
        public double KgEnviados { get; set; }
        public double PorcRendimiento { get; set; }
        public double ProcRendPromedio { get; set; }
        public double PromedioKilosSalidaCharqueador { get; set; }
    }
}
