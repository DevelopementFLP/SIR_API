using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.AplicacionDePedidos.Entidades
{
    [Table("comp_tipo_de_unidad")]
    public class TipoDeUnidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoDeUnidad { get; set; }

        [StringLength(50)]
        public string Codigo { get; set; }

        [StringLength(60)]
        public string Nombre { get; set; }

    }
}
