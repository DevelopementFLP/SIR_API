namespace SistemaIntegralReportes.Servicios
{
    public class FaenaTipificacionChileService : FaenaService
    {
        public FaenaTipificacionChileService(HttpClient httpclient, IConfiguration configuration) : base(httpclient, configuration) { }
        public override string SourceName() => "tipificacionchile";
    }
}
