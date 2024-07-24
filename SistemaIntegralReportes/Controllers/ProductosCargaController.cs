using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaIntegralReportes.Common;
using SistemaIntegralReportes.Models;
using SistemaIntegralReportes.Servicios;
using System.Configuration;
using System.Net.Http;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductosCargaController : ControllerBase
    {
        private readonly ProductosCargaService _cargaService;
        public HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ProductosCargaController(ProductosCargaService cargaService, HttpClient httpClient, IConfiguration configuration)
        {
            _cargaService = cargaService;
            _httpClient = httpClient;
            _configuration = configuration;
            _httpClient.BaseAddress = new Uri(configuration["ConnectionStrings:GecosIntegrationService"]);
        }

        [HttpGet("productosCarga")]
        public async Task<ActionResult<ProductoCarga>> GetAnimalFaena([FromQuery] DateTime fechaDesde, DateTime fechaHasta)
        {
            string formattedDateDesde = fechaDesde.ToString("yyyy-MM-dd");
            string formattedDateHasta = fechaHasta.ToString("yyyy-MM-dd");
            var endpoint = $"carga/productos?fechadesde={formattedDateDesde}&fechahasta={formattedDateHasta}";

            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode) return null;

            string content = await response.Content.ReadAsStringAsync();

            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new SubCategoriaConverter());

            var result = JsonConvert.DeserializeObject<List<ProductoCarga>>(content);

            return result != null ? Ok(result) : NotFound();
        }
    }
}
