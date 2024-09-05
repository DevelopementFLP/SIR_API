namespace SistemaIntegralReportes.Models
{
    public class DataTemperatura
    {
        public int IdDispositivo { get; set; }
        public string CodigoDispositivo { get; set; }
        public string UnidadMedida { get; set; }
        public double Valor {  get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
