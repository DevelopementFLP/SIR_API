using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.DTO.FichaTecnica.Plantillas
{
    public class ResponseAspectosGeneralesDTO
    {
        public string NombreDePlantilla { get; set; }
        public string Marca { get; set; } 
        public string TipoDeUso { get; set; }
        public string Alergeno { get; set; }
        public string Almacenamiento { get; set; }
        public string VidaUtil { get; set; }
        public string TipoDeEnvase { get; set; }
        public string PresentacionDeEnvase { get; set; }
        public decimal PesoPromedio { get; set; }
        public int UnidadesPorCaja { get; set; }
        public string Dimensiones { get; set; }
    }
}
