namespace SistemaIntegralReportes.Models
{
    public partial class ProductoCarga
    {
        public DateTimeOffset Exportdate { get; set; }
        public string Container { get; set; }
        public long Pallet { get; set; }
        public string Productcode { get; set; }
        public string Boxid { get; set; }
        public double Netweight { get; set; }
        public long Grossweight { get; set; }
        public DateTimeOffset Productiondate { get; set; }
        public DateTimeOffset Expiredate { get; set; }
        public bool Finalizada { get; set; }
    }
}
