using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegralreportes.DTO
{
    public class DispositivosDTO
    {
        public int IdDispositivo { get; set; }

        public string? Nombre { get; set; }

        public string Ip { get; set; } = null!;

        public int Puerto { get; set; }

        public string? Descripcion { get; set; }

        public bool? Activo { get; set; }

        public int IdTipo { get; set; }

        public int IdUbicacion { get; set; }

        public int IdFormato { get; set; }

        public virtual FormateosDTO? IdFormatoNavigation { get; set; }
        public virtual TipoDispositivoDTO? IdTipoNavigation { get; set; }
        public virtual UbicacionesDispositivosDTO? IdUbicacionNavigation { get; set; }
    }
}
