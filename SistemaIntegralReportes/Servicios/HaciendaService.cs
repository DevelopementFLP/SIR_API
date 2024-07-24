using Newtonsoft.Json;
using SistemaIntegralReportes.Common;
using SistemaIntegralReportes.Models;
using System.Net.Http;

namespace SistemaIntegralReportes.Servicios
{
    public abstract class HaciendaService
    {
        public HttpClient _httpClient;
        public IConfiguration _configuration;

        public HaciendaService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpClient.BaseAddress = new Uri(configuration["ConnectionStrings:GecosIntegrationService"]);

        }

        public async Task<List<T>?> GetHaciendaData<T>(DateTime fechaDeFaena)
        {
            string formattedDate = fechaDeFaena.ToString("yyyy-MM-dd");
            var endpoint = $"hacienda/{SourceName()}?fechadesde={formattedDate}&fechahasta={formattedDate}";

            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode) return null;

            string content = await response.Content.ReadAsStringAsync();

            List<T> result = JsonConvert.DeserializeObject<List<T>>(content);

            return result;
        }

        public abstract string SourceName();
    }
}
