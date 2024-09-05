namespace SistemaIntegralReportes.Models.StockCajas
{
    public class OrdenArmado
    {
        public int Id_Pedido { get; set; }
        public int Cajas_A_Armar {  get; set; }
        public int Cajas_Armadas { get; set; }
        public int Id_Destino { get; set; }
    }
}
