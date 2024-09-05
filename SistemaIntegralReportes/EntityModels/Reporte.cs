using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaIntegralReportes.EntityModels
{
    public partial class Reporte
    {
        [Key]
        public int IdReporte { get; set; }
        public int IdModulo { get; set; }
        public string NombreReporte { get; set; } = null!;
        public bool Activo { get; set; }
        public string? Icono { get; set; }
        public string? RouterLink { get; set; }
        public string? Target { get; set; }
    }
}
