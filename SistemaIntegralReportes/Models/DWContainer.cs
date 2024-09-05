namespace SistemaIntegralReportes.Models
{
    public class DWContainer
    {
        public int? Id_Carga { get; set; }
        public string Container { get; set; }
        public string BoxId { get; set; }
        public int Id_Pallet { get; set; }
        public DateTime Exportdate { get; set; }
    }
}
