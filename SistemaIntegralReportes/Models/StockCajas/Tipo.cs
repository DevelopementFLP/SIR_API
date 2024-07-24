using System.Text.Json.Serialization;

namespace SistemaIntegralReportes.Models.StockCajas
{
    public class Tipo
    {
        public int Id_Tipo { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}
