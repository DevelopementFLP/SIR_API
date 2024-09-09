namespace SistemaIntegralReportes.DTO.Cuota
{   public class LoteEntradaDTO
    {
        public DateTime Fecha { get; set; }
        public int Lote { get; set; }
        public string Code { get; set; }
        public string TipoCuarto { get; set; }
        public int Cuartos { get; set; }
        public double Peso { get; set; }
    }
}
