namespace SistemaIntegralReportes.Models.StockCajas
{
    public class Pedido
    {
        public int Id_Pedido { get; set; }
        public int Id_Pedido_Padre {  get; set; }
        public int Id_Caja { get; set; }
        public DateTime Fecha_Pedido { get; set; }
        public int Prioridad { get; set; }
        public int Stock_Pedido { get; set; }
        public bool Para_Stock { get; set; }
        public bool Estado { get; set; }
    }
}
