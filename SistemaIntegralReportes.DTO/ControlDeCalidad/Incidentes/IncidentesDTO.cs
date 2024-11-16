using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.DTO.ControlDeCalidad.Incidentes
{
    public class IncidentesDTO
    {
        public int IdIncidente { get; set; }

        public string codigoQr { get; set; }
        public string PuestoDeTrabajo { get; set; }
        public string CodigoDeEmpleado { get; set; }
        public string NombreDeEmpleado { get; set; }
        public string Producto { get; set; }

        public string Hora { get; set; }
        public string TipoDeIncidente { get; set; }
        public string ImagenDeIncidente { get; set; }

        public string FechaDeRegistro { get; set; }
    }
}
