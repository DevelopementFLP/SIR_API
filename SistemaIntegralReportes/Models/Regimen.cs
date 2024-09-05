namespace SistemaIntegralReportes.Models
{
    public class Regimen
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float HorasTrabajadas { get; set; }
        public int InicioNocturnas { get; set; }
        public int FinNocturnas { get; set; }
        public bool Activo { get; set; }
    }
}
