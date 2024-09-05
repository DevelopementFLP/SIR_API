namespace SistemaIntegralReportes.Models
{
    public class ConfigurationParameter
    {
        public int Id { get; set; }
        public int ReporteId {  get; set; }
        public int ModuloId { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public string Activo { get; set; }
    }
}
