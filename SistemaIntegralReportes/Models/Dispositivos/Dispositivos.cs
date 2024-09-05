using SistemaIntegralReportes.Servicios.Contrato;
using SistemaIntegralReportes.Interfaces;

namespace SistemaIntegralReportes.Models.Dispositivos
{
    public partial class Dispositivos
    {
        public Dispositivos()
        {
            Lecturas = new HashSet<Lecturas>();
        }

        public int IdDispositivo { get; set; }
        public string? Nombre { get; set; }
        public string Ip { get; set; } = null!;
        public int Puerto { get; set; }
        public string? Descripcion { get; set; }
        public bool? Activo { get; set; }
        public int IdTipo { get; set; }
        public int IdUbicacion { get; set; }
        public int IdFormato { get; set; }

        public virtual Formateos? IdFormatoNavigation { get; set; } 
        public virtual TipoDispositivos? IdTipoNavigation { get; set; }
        public virtual UbicacionesDispositivos? IdUbicacionNavigation { get; set; }
        public virtual ICollection<Lecturas> Lecturas { get; set; }
    }
}
