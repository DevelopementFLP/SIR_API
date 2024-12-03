using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.AplicacionDePedidos.Entidades
{
    [Table("comp_orden_de_solicitud")]
    public class OrdenDeSolicitud
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrdenDeSolicitud { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime FechaDecreacion { get; set; }

        public int IdEstadoDeSolicitud { get; set; }

        [ForeignKey("IdEstadoDeSolicitud")]
        public virtual EstadoDeSolicitud EstadoDeSolicitud { get; set; }

        public int IdUsuarioSolicitante { get; set; }

        [ForeignKey("IdUsuarioSolicitante")]
        public virtual UsuarioSolicitante UsuarioSolicitante { get; set; }

        public int IdPriodidadDeOrden { get; set; }

        [ForeignKey("IdPriodidadDeOrden")]
        public virtual PrioridadDeOrden PrioridadDeOrden { get; set; }

        public int IdCentroDeCosto { get; set; }

        [ForeignKey("IdCentroDeCosto")]
        public virtual CentroDeCosto CentroDeCosto { get; set; }

        public int IdEmpresa { get; set; }
        [ForeignKey("IdEmpresa")]
        public virtual Empresa Empresa { get; set; }
    }
}
