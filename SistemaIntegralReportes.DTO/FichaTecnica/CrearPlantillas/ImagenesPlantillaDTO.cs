using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.DTO.FichaTecnica.CrearPlantillas
{
    public class ImagenesPlantillaDTO
    {
        public int IdFoto { get; set; }
        public string codigoDeProducto { get; set; }
        public int SeccionDeImagen { get; set; }
        public string ContenidoImagen { get; set; }

    }
}
