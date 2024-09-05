namespace SistemaIntegralReportes.Models.Dispositivos
{
    public partial class Lecturas
    {
        public int IdLectura { get; set; }
        public int IdDispositivo { get; set; }
        public string? Mensaje { get; set; }
        public DateTime FechaHora { get; set; }
        public virtual Dispositivos IdDispositivoNavigation { get; set; } = null!;
    }
}
