namespace SistemaIntegralReportes.Models
{
    using Newtonsoft.Json;
    using System;

    public partial class AnimalHacienda
    {
        [JsonProperty("fechaFaena")]
        public DateTimeOffset FechaFaena { get; set; }

        [JsonProperty("tropa")]
        public long Tropa { get; set; }

        [JsonProperty("lote")]
        public long Lote { get; set; }

        [JsonProperty("ordinalAnimal")]
        public int OrdinalAnimal { get; set; }

        [JsonProperty("rechazada")]
        public long Rechazada { get; set; }

        [JsonProperty("segregada")]
        public long Segregada { get; set; }

        [JsonProperty("especie")]
        public string Especie { get; set; }
    }
}
