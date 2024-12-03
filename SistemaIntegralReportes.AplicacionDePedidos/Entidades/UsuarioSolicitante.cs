using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.AplicacionDePedidos.Entidades
{
    [Table("comp_usuario_solicitante")]
    public class UsuarioSolicitante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuarioSolicitante { get; set; }

        [StringLength(70)]
        [Required]
        public string Nombre { get; set; }

        [StringLength(70)]
        [Required]
        public string Apellido { get; set; }

        public int IdDepartamento { get; set; }

        [ForeignKey("IdDepartamento")]
        public virtual Departamento Departamento { get; set; }

        public int IdRol { get; set; }

        [ForeignKey("IdRol")]
        public virtual RolDeUsuario Rol { get; set; }

    }
}
