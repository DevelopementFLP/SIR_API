namespace SistemaIntegralReportes.Models
{
    public class ProductosPorEstacion
    {
        public string CodProd {  get; set; }
        public string Producto {  get; set; }
        public int? Cajas { get; set; }
        public int? Cortes { get; set; }
        public double Peso { get; set; }
    }
}
