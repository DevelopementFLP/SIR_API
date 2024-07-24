namespace SistemaIntegralReportes.Models.StockCajas
{
    public class OrdenEntrega
    {
        public int Id_Pedido { get; set; }
        public int Cajas_A_Entregar { get; set; }
        public int Cajas_Entregadas { get; set; }
    }
}
