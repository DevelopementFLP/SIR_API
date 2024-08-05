using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralreportes.DTO
{
    public class TipoDispositivoDTO
    {
        public int IdTipo { get; set; }
        public string Nombre { get; set; } = null!;
        public string? ComandoInicio { get; set; }
        public string? ComandoFin { get; set; }
    }
}
