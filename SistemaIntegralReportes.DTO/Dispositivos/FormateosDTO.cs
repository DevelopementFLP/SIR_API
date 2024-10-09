using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.DTO.Dispositivos
{
    public class FormateosDTO
    {
        public int IdFormato { get; set; }
        public int SubstringDesde { get; set; }
        public int SubstringHasta { get; set; }
        public string? ErrorLectura { get; set; }
    }
}
