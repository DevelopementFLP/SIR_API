using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaIntegralReportes.EntityModels
{
    public partial class ConfAcceso
    {
        [Key]
        public int IdAcceso { get; set; }

        [ForeignKey("IdModulo")]
        public int IdModulo { get; set; }

        [ForeignKey("IdPerfil")]
        public int IdPerfil { get; set; }
        public bool Permitido { get; set; }

        public virtual ConfModulo IdModuloNavigation { get; set; } = null!;
        public virtual ConfPerfile IdPerfilNavigation { get; set; } = null!;
    }
}
