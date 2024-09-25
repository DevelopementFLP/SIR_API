namespace SistemaIntegralReportes.DTO.Cuota
{
    public class DWCajaSalidaDTO
    {
        public DateTime Fecha {  get; set; }
        public string? Condition { get; set; }
        public int? Qamark { get; set; }
        public string? Customercode { get; set; }
        public string Code { get; set; }
        public string Producto { get; set; }
        public int Piezas { get; set; }
        public int Cajas { get; set; }
        public double Peso { get; set; }
    }
}
