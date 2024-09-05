using System;
using System.Text.Json.Serialization;

namespace SistemaIntegralReportes.Models
{
    public partial class SalidaProduccionGecos
    {
        [JsonPropertyName("fechaProd")]
        public DateTimeOffset FechaProd { get; set; }

        [JsonPropertyName("fechaFaena")]
        public DateTimeOffset FechaFaena { get; set; }

        [JsonPropertyName("idCajaGecos")]
        public long IdCajaGecos { get; set; }

        [JsonPropertyName("codProducto")]
        public string CodProducto { get; set; }

        [JsonPropertyName("nomProducto")]
        public string NomProducto { get; set; }

        [JsonPropertyName("peso")]
        public double Peso { get; set; }

        [JsonPropertyName("sala")]
        public string Sala { get; set; }

        [JsonPropertyName("puesto")]
        public string Puesto { get; set; }

        [JsonPropertyName("codProceso")]
        public string CodProceso { get; set; }

        [JsonPropertyName("codPrograma")]
        public string CodPrograma { get; set; }

        [JsonPropertyName("ph")]
        public bool Ph { get; set; }

        [JsonPropertyName("cantidad")]
        public long Cantidad { get; set; }

        [JsonPropertyName("pesoBruto")]
        public double PesoBruto { get; set; }

        [JsonPropertyName("tara")]
        public double Tara { get; set; }

        [JsonPropertyName("idCorrelPadre")]
        public long IdCorrelPadre { get; set; }

        [JsonPropertyName("turno")]
        public int Turno { get; set; }

        [JsonPropertyName("fechaModif")]
        public DateTimeOffset FechaModif { get; set; }

        [JsonPropertyName("dotNumberINAC")]
        public string DotNumberInac { get; set; }

        [JsonPropertyName("fechaCongelado")]
        public DateTimeOffset FechaCongelado { get; set; }

        [JsonPropertyName("fechaProducido")]
        public DateTimeOffset FechaProducido { get; set; }

        [JsonPropertyName("fechaVencimiento")]
        public DateTimeOffset FechaVencimiento { get; set; }

        [JsonPropertyName("categoria")]
        public int Categoria { get; set; }

        [JsonPropertyName("codCliente")]
        public string CodCliente { get; set; }

        [JsonPropertyName("nomCliente")]
        public string NomCliente { get; set; }

        [JsonPropertyName("codCamion")]
        public string CodCamion { get; set; }

        [JsonPropertyName("nomCamion")]
        public string NomCamion { get; set; }

        [JsonPropertyName("desvio")]
        public string Desvio { get; set; }

        [JsonPropertyName("codigoKosher")]
        public string CodigoKosher { get; set; }

        [JsonPropertyName("especie")]
        public string Especie { get; set; }

        [JsonPropertyName("destino")]
        public string Destino { get; set; }

        [JsonPropertyName("origenCaja")]
        public string OrigenCaja { get; set; }
    }
}
