

namespace SistemaIntegralReportes.Models.Dispositivos
{
    public partial class Formateos
    {
        public Formateos()
        {
            Dispositivos = new HashSet<Dispositivos>();
        }

        public int IdFormato { get; set; }
        public int SubstringDesde { get; set; }
        public int SubstringHasta { get; set; }
        public string? ErrorLectura { get; set; }

        public virtual ICollection<Dispositivos> Dispositivos { get; set; }
    }
}
