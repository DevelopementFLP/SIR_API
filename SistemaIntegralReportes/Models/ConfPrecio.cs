namespace SistemaIntegralReportes.Models
{
    public class ConfPrecio
    {
        public DateTime Fecha_Produccion { get; set; }
        public string Codigo_Producto { get; set; }
        public double Precio_Tonelada { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Moneda { get; set; }
    }
}
