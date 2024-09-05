namespace SistemaIntegralReportes.Models.StockCajas
{
    public class Diseno
    {
        public int Id_Diseno { get; set; }
        public string Nombre { get; set; }
        public string? Url { get; set; } = null;
        public bool Estado { get; set; }
    }
}
