using Newtonsoft.Json;
using SistemaIntegralReportes.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SistemaIntegralReportes.Servicios
{
    public class AnimalHaciendaService : HaciendaService
    {

        public AnimalHaciendaService(HttpClient httpClient, IConfiguration configuration): base(httpClient, configuration)
        {
        }
    
        public override string SourceName() => "animales";

    }
}
