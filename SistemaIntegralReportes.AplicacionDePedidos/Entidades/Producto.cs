using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.AplicacionDePedidos.Entidades
{
    [Table("comp_producto")]
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }

        [StringLength(60)]
        public string CodigoDeProducto { get; set; }

        [StringLength(60)]
        public string CodigoDeProductoAlternativo { get; set; }

        [StringLength(60)]
        public string CodigoDeProductoAlternativo2 { get; set; }

        public DateTime FechaDeRegistro { get; set; }

        public DateTime FechaDeActualizacion { get; set; }

        [StringLength(60)]
        public string Nombre { get; set; }

        public int IdTipoDeUnidad { get; set; }

        [ForeignKey("IdTipoDeUnidad")]
        public virtual TipoDeUnidad TipoDeUnidad { get; set; }

        [StringLength(150)]
        public string Descripcion { get; set; }
    }
}
