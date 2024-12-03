using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.Aplicacion.Android.Entidades.Incidente
{
    [Table("test_incidentes")]
    public class Incidente
    {
        [Key]
        public int IdIncidente { get; set; }

        [StringLength(100)]
        public string codigoQr { get; set; }

        [StringLength(100)]
        public string PuestoDeTrabajo { get; set; }

        [StringLength(100)]
        public string CodigoDeEmpleado { get; set; }

        [StringLength(100)]
        public string NombreDeEmpleado { get; set; }

        [StringLength(100)]
        public string Producto { get; set; }


        [StringLength(100)]
        public string Hora { get; set; }

        public int IdTipoDeIncidente { get; set; }

        [ForeignKey("IdTipoDeIncidente")]
        public virtual TipoDeIncidente TipoDeIncidente { get; set; }

        [Column(TypeName = "varbinary(MAX)")]
        public string ImagenDeIncidente { get; set; }

        [StringLength(100)]
        public string CodigoDeProducto { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime FechaDeRegistro { get; set; }

    }
}
