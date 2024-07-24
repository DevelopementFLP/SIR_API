using Newtonsoft.Json;
using SistemaIntegralReportes.Common;
using System;


namespace SistemaIntegralReportes.Servicios
{
    public abstract class ProduccionService
    {
        public HttpClient _httpClient;
        public IConfiguration _configuration;

        public ProduccionService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpClient.BaseAddress = new Uri(configuration["ConnectionStrings:GecosIntegrationService"]);
        }

        public async Task<List<T>> GetProduccionData<T>(DateTime fechaDeFaena)
        {
            string formattedDate = fechaDeFaena.ToString("yyyy-MM-dd");
            var endpoint = $"produccion/{SourceName()}?fechadesde={formattedDate}&fechahasta={formattedDate}";

            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode) return null;

            string content = await response.Content.ReadAsStringAsync();

            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new SubCategoriaConverter());

            List<T> result = JsonConvert.DeserializeObject<List<T>>(content);

            return result;
        }

        public async Task<IEnumerable<T>> GetProduccionDataConFiltro<T>(DateTime fechaDesde, DateTime fechaHasta, string filtro)
        {
            string formattedFechaDesde = fechaDesde.ToString("yyyy-MM-dd");
            string formattedFechaHasta = fechaHasta.ToString("yyyy-MM-dd");

            var endpoint = $"produccion/{SourceName()}?fechadesde={formattedFechaDesde}&fechahasta={formattedFechaHasta}&filtrouniversal={filtro}";
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode) return null;

            string content = await response.Content.ReadAsStringAsync();

            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new SubCategoriaConverter());

            IEnumerable<T> result = JsonConvert.DeserializeObject<IEnumerable<T>>(content);
            return result;
        }

        public abstract string SourceName();
    }
}
