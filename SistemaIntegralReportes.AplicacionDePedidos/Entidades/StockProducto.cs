using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.AplicacionDePedidos.Entidades
{
    [Table("comp_stock_producto")]
    public class StockProducto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStockProducto { get; set; }

        public int IdAlmacen { get; set; }
        [ForeignKey("IdAlmacen")]
        public virtual Almacen Almacen { get; set; }

        public int IdProducto { get; set; }

        [ForeignKey("IdProducto")]
        public virtual Producto Producto { get; set; }

        public int IdEmpresa { get; set; }

        [ForeignKey("IdEmpresa")]
        public virtual Empresa Empresa { get; set; }

        public int Stock { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime FechaDeActualizacion { get; set; }
    }
}
