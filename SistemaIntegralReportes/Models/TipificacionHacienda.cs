using Newtonsoft.Json;
using SistemaIntegralReportes.Common;
using System.Text.Json.Serialization;

namespace SistemaIntegralReportes.Models
{
    public partial class TipificacionHacienda
    {
        public DateTimeOffset FechaFaena { get; set; }
        public Especie Especie { get; set; }
        public long Anio { get; set; }
        public long Tropa { get; set; }
        public long Lote { get; set; }
        public Categoria Categoria { get; set; }
        public Raza Raza { get; set; }
        public Calidad Calidad { get; set; }
        public string SubCategoria { get; set; }
        public Tipificacion Tipificacion { get; set; }
    }

    public enum Calidad { Gordo, Toruno };

    public enum SubCategoria { NovillitoDI, NovillitoJoven24D, Novillo, Novillo6Dientes, Vaca, Vaca6Dientes, Vaquillona024D };

    public enum Tipificacion { Empty, A, C, N, U, V, B1, B3, D1, D2 };
}
