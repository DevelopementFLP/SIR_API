namespace SistemaIntegralReportes.Models
{
    public partial class TipificacionChile
    {
        public DateTimeOffset Fecha { get; set; }
        public string Chile { get; set; }
        public long Reses { get; set; }
        public long Tropa { get; set; }
        public string Especie { get; set; }
        public long Lado { get; set; }
        public long Denticion { get; set; }
        public string Grading { get; set; }
        public long PesoNeto { get; set; }
        public long CorrelFaena { get; set; }
        public string Categoria { get; set; }
        public long Grasa { get; set; }
        public long CodProveedor { get; set; }
        public long DotNumber { get; set; }
        public DateTimeOffset FechaEtiqueta { get; set; }
        public DateTimeOffset FechaUpd { get; set; }
        public string Inacur { get; set; }
        public long CategoriaAnimal { get; set; }
        public string Yieldgroup { get; set; }
        public string Caravana { get; set; }
    }
}

