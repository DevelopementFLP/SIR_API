using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.DTO.AplicacionDePedidos
{
    //Cambiar el nombre de la tabla 
    //[Table("Nombre de la tabla que quiera")]
    public class CentroDeCosto
    {
        [Key]  // Indicamos explícitamente que es la clave primaria
        public int IdCentroDeCosto { get; set; }

        //Largo maximo de caracteres
        [StringLength(50)] //nvarchar 50
        [Required] // campo not null        
        public string nombre{ get; set; }

        [Column(TypeName = "date")] //colocar el tipo de dato para la fecha en la BD
        public DateTime fecha { get; set; }

    
    }
}
