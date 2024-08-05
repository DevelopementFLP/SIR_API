using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralreportes.DTO
{
    public class LecturasDTO
    {
        public int IdLectura { get; set; }
        public int IdDispositivo { get; set; }
        public string? Mensaje { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
