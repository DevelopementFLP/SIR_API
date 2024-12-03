using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.AplicacionDePedidos.Entidades
{
    [Table("comp_estado_de_solicitud")]
    public class EstadoDeSolicitud
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstadoDeSolicitud { get; set; }

        [StringLength(50)]
        [Required]
        public string Nombre { get; set; }

    }
}
