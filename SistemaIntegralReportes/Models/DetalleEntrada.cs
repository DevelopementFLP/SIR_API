namespace SistemaIntegralReportes.Models
{
    public class DetalleEntrada
    {
        public string TipoEntrada { get; set; }
        public string Codigo { get; set; }
        public string Producto { get; set; }
        public int Cuartos { get; set; }
        public double PesoCuartos { get; set; }
        public double Promedio { get; set; }
        public string HoraPrimerCuarto { get; set; }
        public string HoraUltimoCuarto { get; set; }
    }
}
