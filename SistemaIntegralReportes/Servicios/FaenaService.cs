using Newtonsoft.Json;
using SistemaIntegralReportes.Common;

namespace SistemaIntegralReportes.Servicios
{
    public abstract class FaenaService
    {
        public HttpClient _httpClient;
        public IConfiguration _configuration;

        public FaenaService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpClient.BaseAddress = new Uri(configuration["ConnectionStrings:GecosIntegrationService"]);

        }

        public async Task<List<T>> GetFaenaData<T>(DateTime fechaDeFaena)
        {
            string formattedDate = fechaDeFaena.ToString("yyyy-MM-dd");
            var endpoint = $"faena/{SourceName()}?fechadesde={formattedDate}&fechahasta={formattedDate}";

            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode) return null;

            string content = await response.Content.ReadAsStringAsync();

            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new SubCategoriaConverter());

            List<T> result = JsonConvert.DeserializeObject<List<T>>(content);

            return result;
        }

        public abstract string SourceName();
    }
}
