namespace SistemaIntegralReportes.Servicios
{
    public class TipificacionHaciendaService : HaciendaService
    {
        public TipificacionHaciendaService(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration)
        { }

        public override string SourceName() => "tipificacion";
    }
}
