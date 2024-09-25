namespace SistemaIntegralReportes.DTO.Cuota
{
    public class DWSalidaDTO
    {
        public DateTime Fecha {  get; set; }
        public int Lote { get; set; }
        public string Customer { get; set; }
        public string Condition { get; set; }
        public int Marca { get; set; }
        public int Material { get; set; }
        public string Codigo { get; set; }
        public string Producto { get; set; }
        public int Piezas { get; set; }
        public double Peso { get; set; }
    }
}
