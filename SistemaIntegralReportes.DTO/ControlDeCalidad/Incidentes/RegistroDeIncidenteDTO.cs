using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.DTO.ControlDeCalidad.Incidentes
{
    public class RegistroDeIncidenteDTO
    {
        public int IdIncidente { get; set; }

        public string codigoQr { get; set; }
        public string PuestoDeTrabajo { get; set; }
        public string Empleado { get; set; }
        public string Producto { get; set; }
        public string Hora { get; set; }
        public int IdTipoDeIncidente { get; set; }
        public string ImagenDeIncidente { get; set; }

    }
}
