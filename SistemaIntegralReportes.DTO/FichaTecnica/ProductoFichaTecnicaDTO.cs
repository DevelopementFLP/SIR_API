using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.DTO.FichaTecnica
{
    public class ProductoFichaTecnicaDTO
    {
        public int IdProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string Nombre { get; set; }
        public string NombreDeProductoParaFicha { get; set; }
        public string Calibre { get; set; }
    }
}
