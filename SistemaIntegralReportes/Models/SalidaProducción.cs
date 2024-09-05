namespace SistemaIntegralReportes.Models
{
    public partial class SalidaProduccion
    {
        public DateTimeOffset FechaProd { get; set; }
        public DateTimeOffset FechaFaena { get; set; }
        public long IdCajaGecos { get; set; }
        public long CodProducto { get; set; }
        public string NomProducto { get; set; }
        public double Peso { get; set; }
        public string Sala { get; set; }
        public string Puesto { get; set; }
        public string CodProceso { get; set; }
        public string CodPrograma { get; set; }
        public bool Ph { get; set; }
        public long Cantidad { get; set; }
        public double PesoBruto { get; set; }
        public long Tara { get; set; }
        public long IdCorrelPadre { get; set; }
        public long Turno { get; set; }
        public DateTimeOffset FechaModif { get; set; }
        public string DotNumberInac { get; set; }
        public DateTimeOffset FechaCongelado { get; set; }
        public DateTimeOffset FechaProducido { get; set; }
        public DateTimeOffset FechaVencimiento { get; set; }
        public long Categoria { get; set; }
        public string CodCliente { get; set; }
        public string NomCliente { get; set; }
        public string CodCamion { get; set; }
        public string NomCamion { get; set; }
        public string Desvio { get; set; }
        public string CodigoKosher { get; set; }
        public string Especie { get; set; }
        public string Destino { get; set; }
        public string OrigenCaja { get; set; }
    }
}
