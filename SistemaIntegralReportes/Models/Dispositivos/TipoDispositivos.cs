using System;
using System.Collections.Generic;

namespace SistemaIntegralReportes.Models.Dispositivos
{
    public partial class TipoDispositivos
    {
        public TipoDispositivos()
        {
            Dispositivos = new HashSet<Dispositivos>();
        }

        public int IdTipo { get; set; }
        public string Nombre { get; set; } = null!;
        public string? ComandoInicio { get; set; }
        public string? ComandoFin { get; set; }

        public virtual ICollection<Dispositivos> Dispositivos { get; set; }
    }
}
