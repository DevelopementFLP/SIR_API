using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.DTO.ControlDeCalidad.Incidentes
{
    public class TrazabilidadDTO
    {
        public Int32 Secuencia { get; set; }

        public string Puesto { get; set; }

        public string IdElemento { get; set; }

        public string Empleado { get; set; }

        public string Producto { get; set; }

        public string Etiqueta { get; set; }

        public string Peso { get; set; }

        public string Hora { get; set; }
    }
}
