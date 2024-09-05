namespace SistemaIntegralReportes.Models
{
    public class ConfPrecioDTO
    {
        public DateTime Fecha_Produccion { get; set; }
        public string Codigo_Producto { get; set; }
        public double Precio_Tonelada { get; set; }
        public int Id_Moneda { get; set; }
    }
}
