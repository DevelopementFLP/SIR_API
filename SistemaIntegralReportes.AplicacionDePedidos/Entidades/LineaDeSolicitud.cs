using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.AplicacionDePedidos.Entidades
{
    [Table("comp_linea_de_solicitud")]
    public class LineaDeSolicitud
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLineaDeSolicitud { get; set; }

        public int IdOrdenDeSolicitud { get; set; }

        [ForeignKey("IdOrdenDeSolicitud")]
        public virtual OrdenDeSolicitud OrdenDeSolicitud { get; set; }

        public int IdProducto { get; set; }

        [ForeignKey("IdProducto")]
        public virtual Producto Producto  { get; set; }

        public int IdAreaDestino { get; set; }

        [ForeignKey("IdAreaDestino")]
        public virtual AreaDestino AreaDestino { get; set; }

        public int Cantidad { get; set; }

    }
}
