using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.DTO.FichaTecnica.CrearPlantillas
{
    public class EspecificacionesPlantillaDTO
    {
        public int IdPlantilla { get; set; }
        public string SeccionDePlantilla { get; set; }
        public string Nombre { get; set; }
        public string GrasaVisible { get; set; }
        public string EspesorCobertura { get; set; }
        public string Ganglios { get; set; }
        public string Hematomas { get; set; }
        public string HuesosCartilagos { get; set; }
        public string ElementosExtraños { get; set; }
        public int IdColor { get; set; }
        public int IdOlor { get; set; }
        public int IdPh { get; set; }
        public string AerobiosMesofilosTotales { get; set; }
        public string Enterobacterias { get; set; }
        public string Stec0157 { get; set; }
        public string StecNo0157 { get; set; }
        public string Salmonella { get; set; }
        public string Estafilococos { get; set; }
        public string Pseudomonas { get; set; }
        public string EscherichiaColi { get; set; }
        public string ColiformesTotales { get; set; }
        public string ColiformesFecales { get; set; }
    }
}
