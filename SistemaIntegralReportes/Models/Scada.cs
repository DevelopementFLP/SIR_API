namespace SistemaIntegralReportes.Models
{
    public class Scada
    {
        public int Id { get; set; }
        public string DeviceId { get; set; }
        public int IdTipoDispositivo { get; set; }
        public int IdUbicacion { get; set; }
        public int IdUnidadMedida { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
