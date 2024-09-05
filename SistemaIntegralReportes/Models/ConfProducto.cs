namespace SistemaIntegralReportes.Models
{
    public class ConfProducto
    {
        public string CodigoProducto { get; set; }
        public string NomProducto { get; set; }         
        public string? CodigoKosher { get; set; }
        public string? ClasificacionKosher { get; set; }
        public string? MarkKosher { get; set; }
        public string? Especie {  get; set; }
        public string? TipoProducto { get; set; }
    }
}
