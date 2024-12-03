using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.AplicacionDePedidos.Entidades
{
    [Table("comp_departamento")]
    public class Departamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDepartamento { get; set; }

        [StringLength(70)]
        public string Codigo { get; set; }

        [StringLength(70)]
        [Required]
        public string Nombre { get; set; }

    }
}
