using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.DTO.FichaTecnica.CrearPlantillas
{
    public class AspectosGeneralesPlantillaDTO
    {
        public int IdPlantilla { get; set; }
        public string SeccionDePlantilla { get; set; }
        public string Nombre { get; set; }

        public string NombreDeProducto { get; set; }
        public int IdMarca { get; set; }
        public int IdTipoDeUso { get; set; }
        public int IdAlergeno { get; set; }
        public int IdCondicionAlmacenamiento { get; set; }
        public int IdVidaUtil { get; set; }
        public int IdTipoDeEnvase { get; set; }
        public int IdPresentacionDeEnvase { get; set; }
        public string PesoPromedio { get; set; }
        public string UnidadesPorCaja { get; set; }
        public string Dimensiones { get; set; }
    }
}
