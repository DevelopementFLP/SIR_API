using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.AplicacionDePedidos.Entidades
{
    [Table("comp_centro_de_costo")]
    public class CentroDeCosto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCentroDeCosto { get; set; }

        [StringLength(70)]
        [Required]
        public string Nombre { get; set; }

        public int IdEmpresa { get; set; }

        public int Codigo { get; set; }

        [StringLength(50)]
        public string CodigoAlternativo { get; set; }

    }
}
