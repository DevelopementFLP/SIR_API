using System.ComponentModel.DataAnnotations;

namespace SistemaIntegralReportes.EntityModels
{
    public partial class PCC
    {
        [Key]
        public int Id { get; set; }
        public string Especie { get; set; }
        public Int16 HoraInicioFaena { get; set; }
        public string HorarioPcc { get; set; }
        public Int16 NumeroPcc { get; set; }
    }
}
