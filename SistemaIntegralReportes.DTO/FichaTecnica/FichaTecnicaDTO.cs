using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.DTO.FichaTecnica
{
    public class FichaTecnicaDTO
    {
        public int IdFichaTecnica { get; set; }
        public string Nombre { get; set; }
        public string Observacion { get; set; }
        public string ElaboradoPor { get; set; }
        public string AprobadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
