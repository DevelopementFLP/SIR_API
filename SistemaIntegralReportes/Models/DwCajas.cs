namespace SistemaIntegralReportes.Models
{
    public class DwCajas
    {
        public int Id { get; set; }
        public string SisOrigen { get; set; }
        public int? IdGecos { get; set; }
        public int? IdInnova { get; set; }
        public string NumberInnova { get; set; }
        public string ExtNumInnova { get; set; }
        public string FixCodeInnova { get; set; }
        public string ExtCodeInnova { get; set; }
        public float? CL { get; set; }
        public int? IdUniProceso { get; set; }
        public string UniProceso { get; set; }
        public string CodProducto { get; set; }
        public string NomProducto { get; set; }
        public string NomCortoProducto { get; set; }
        public int? IdTipoProducto { get; set; }
        public string NomTipoProducto { get; set; }
        public float? PesoNeto { get; set; }
        public float? PesoBruto { get; set; }
        public float? Tara { get; set; }
        public int? Unidades { get; set; }
        public int? Turno { get; set; }
        public string Destino { get; set; }
        public int? IdDesvio { get; set; }
        public string NomDesvio { get; set; }
        public DateTime? FechaProducido { get; set; }
        public DateTime? FechaCorrida { get; set; }
        public DateTime? FechaFaena { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaCerrado { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaCongelado { get; set; }
        public DateTime? FechaVencimiento1 { get; set; }
        public DateTime? FechaVencimiento2 { get; set; }
        public int? IdPallet { get; set; }
        public string IdContenedor { get; set; }
        public string CodCliente { get; set; }
        public string NomCliente { get; set; }
        public string CodBarras { get; set; }
        public string Especie { get; set; }
        public string Estado { get; set; }
        public int? Tipo { get; set; }
    }
}
