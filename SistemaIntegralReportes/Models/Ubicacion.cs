namespace SistemaIntegralReportes.Models
{
    public class Ubicacion  
    {
        public int IdUbicacion { get; set; }
        public int IdUbicacionPadre { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
