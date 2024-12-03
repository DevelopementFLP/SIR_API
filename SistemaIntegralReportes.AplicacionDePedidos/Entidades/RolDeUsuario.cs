using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.AplicacionDePedidos.Entidades
{
    [Table("comp_rol_de_usuario")]
    public class RolDeUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRol { get; set; }

        [StringLength(70)]
        public string Nombre { get; set; }
    }
}
