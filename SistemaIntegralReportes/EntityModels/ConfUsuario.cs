using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaIntegralReportes.EntityModels
{
    public partial class ConfUsuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public bool Activo { get; set; }
        public string NombreCompleto { get; set; } = null!;

        public virtual ConfPerfile IdPerfilNavigation { get; set; } = null!;
    }
}
