namespace SistemaIntegralReportes.Models
{
    public class DWCajaCarga
    {
        public int? Id_Carga {  get; set; }
        public int? Id_Pallet { get; set; }
        public string Container {  get; set; }
        public string BoxId { get; set; }
        public DateTime? ExportDate { get; set; }
        public string SisOrigen { get; set; }
        public string IdLargo { get; set; }
        public int? IdInnova { get; set; }
        public int? IdGecos { get; set; }
        public string? ExtCodeInnova { get; set; }
        public string CodProducto { get; set; }
        public string? CodigoKosher { get; set; }
        public double? PesoNeto { get; set; }
        public double? PesoBruto { get; set; }
        public DateTime? FechaCorrida { get; set; }
        public DateTime? FechaVencimiento_1 { get; set; }
        public DateTime? FechaVencimiento_2 { get; set; }
        public string? Especie { get; set; }
        public string? NomTipoProducto { get; set; }
    }
}
