using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.Aplicacion.Android.Entidades.Incidente
{
    [Table("test_tipo_de_incidente")]
    public class TipoDeIncidente
    {
        [Key]
        public Int32 IdTipoDeIncidente { get; set; }

        [StringLength(200)]
        public string Descripcion { get; set; }

        public int IdSectorDeIncidente { get; set; }

        [ForeignKey("IdSectorDeIncidente")]
        public virtual SectorDeIncidente SectorDeIncidente { get; set; }

    }
}
