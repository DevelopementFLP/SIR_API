namespace SistemaIntegralReportes.Models.Dispositivos
{
    public partial class UbicacionesDispositivos
    {
        public UbicacionesDispositivos()
        {
            Dispositivos = new HashSet<Dispositivos>();
        }

        public int IdUbicacion { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }
        public virtual ICollection<Dispositivos> Dispositivos { get; set; }
    }
}
