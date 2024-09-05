namespace SistemaIntegralReportes.Models.StockCajas
{
    public class Caja
    {
        public int Id_Caja { get; set; }
        public int Id_Diseno { get; set; }

        public int Id_Tamano { get; set; }

        public int Id_Tipo { get; set; }

        public string Nombre { get; set; }
        public int Stock_Minimo { get; set; }

    }
}
