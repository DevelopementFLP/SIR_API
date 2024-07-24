namespace SistemaIntegralReportes.Models
{
    public class IndicadorHueseros
    {
        public int Linea { get; set; }
        public Int32 IdEstacion { get; set; }
        public string NombreEstación { get; set; }
        public string HueseroCod { get; set; }
        public string Huesero { get; set; }
        public int Cuartos { get; set; }
        public double KgRecibidos { get; set; }
        public double KgEnviados { get; set; }
        public double Rend { get; set; }
    }
}
