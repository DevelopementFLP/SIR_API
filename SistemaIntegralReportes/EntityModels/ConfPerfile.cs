using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaIntegralReportes.EntityModels
{
    public partial class ConfPerfile
    {
        public ConfPerfile()
        {
            ConfAccesos = new HashSet<ConfAcceso>();
            ConfUsuarios = new HashSet<ConfUsuario>();
        }

        [Key]
        public int IdPerfil { get; set; }
        public string? NombrePerfil { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<ConfAcceso> ConfAccesos { get; set; }
        public virtual ICollection<ConfUsuario> ConfUsuarios { get; set; }
    }
}
