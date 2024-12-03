using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.AplicacionDePedidos.Entidades
{
    [Table("comp_ubicacion_destino")]
    public class UbicacionDestino
    {
        [Key]
        public int IdUbicacionDestino { get; set; }

        public Almacen Almacen { get; set; }

        [StringLength(150)]
        [Required]
        public string Descripcion { get; set; }
    }
}
