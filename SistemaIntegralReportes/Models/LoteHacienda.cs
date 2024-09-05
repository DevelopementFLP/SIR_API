namespace SistemaIntegralReportes.Models
{
    public partial class LoteHacienda
    {
        public DateTimeOffset FechaFaena { get; set; }
        public long Tropa { get; set; }
        public Categoria Categoria { get; set; }
        public Raza Raza { get; set; }
        public long Lote { get; set; }
        public long Kilosprimera { get; set; }
        public long Reses { get; set; }
        public long Rechazados { get; set; }
        public string Productor { get; set; }
        public Especie Especie { get; set; }
    }

    public enum Categoria { Novillo, Vaca, Vaquillona };

    public enum Especie { B };

    public enum Raza { Angus, Cruza };


}
