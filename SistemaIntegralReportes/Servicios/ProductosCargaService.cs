namespace SistemaIntegralReportes.Servicios
{
    public class ProductosCargaService : CargaService
    {
        public ProductosCargaService(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration) { }
        public override string SourceName() => "productos";
    }
}
