using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.DTO.Dispositivos
{
    public class UbicacionesDispositivosDTO
    {
        public int IdUbicacion { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
