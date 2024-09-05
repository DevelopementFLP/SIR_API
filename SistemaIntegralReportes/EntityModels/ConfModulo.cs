using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaIntegralReportes.EntityModels
{
    public partial class ConfModulo
    {
        public ConfModulo()
        {
            ConfAccesos = new HashSet<ConfAcceso>();
        }

        [Key]
        public int IdModulo { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Icono { get; set; }
        public string? RouteLink { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<ConfAcceso> ConfAccesos { get; set; }
    }
}
