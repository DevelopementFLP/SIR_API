using Newtonsoft.Json;
using SistemaIntegralReportes.Models;

namespace SistemaIntegralReportes.Servicios
{
    public class LoteHaciendaService : HaciendaService //ILoteFaenaService
    {
        private readonly HttpClient _httpClient;

        public LoteHaciendaService(HttpClient httpClient, IConfiguration configuration): base(httpClient, configuration)
        {
            /*_httpClient = httpClient;
            string baseAddress = configuration["ConnectionStrings:GecosIntegrationService"];
            _httpClient.BaseAddress = new Uri(baseAddress);*/
        }

        public override string SourceName() => "lotes";

        /*public async Task<List<LoteFaena>> GetLoteFaenaData(DateTime fechaDeFaena)
        {
            string formattedDate = fechaDeFaena.ToString("yyyy-MM-dd");
            var endpoint = $"hacienda/lotes?fechadesde={formattedDate}&fechahasta={formattedDate}";

            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode) return null;

            string content = await response.Content.ReadAsStringAsync();
            List<LoteFaena> result = JsonConvert.DeserializeObject<List<LoteFaena>>(content);

            return result;
        }*/



    }
}
