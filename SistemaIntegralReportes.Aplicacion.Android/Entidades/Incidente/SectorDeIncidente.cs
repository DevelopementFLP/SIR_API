using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.Aplicacion.Android.Entidades.Incidente
{
    [Table("test_sector_de_incidente")]
    public class SectorDeIncidente
    {
        [Key]
        public int IdSectorIncidente { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

    }
}
