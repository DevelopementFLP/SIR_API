namespace SistemaIntegralReportes.Models
{
    public class MarelDataResult
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Producto { get; set; }
        public string Destino { get; set; }
        public DateTime FechaProduccion { get; set; }
        public DateTime FechaFaena { get; set; }
    }
}
