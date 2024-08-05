using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralreportes.DTO
{
    public class ResponseDto<Modelo>
    {       
        //retorna el resultado, osea el modelo
        public Modelo? Resultado { get; set; }
        //funciono bien o no
        public bool EsCorrecto { get; set; }
        //el mensaje de error 
        public string? Mensaje { get; set; }
    }
}
