namespace SistemaIntegralReportes.Servicios
{
    public class SalidaProduccionService : ProduccionService
    {
        public SalidaProduccionService(HttpClient httpClient, IConfiguration configuration): base(httpClient, configuration) { }
        public override string SourceName() => "salidas";
    }
}
