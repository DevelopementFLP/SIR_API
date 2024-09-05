using GecosIntegrationBrokerService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralReportes.Models;
using SistemaIntegralReportes.Servicios;
using System.Text.Json;


namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class GecosIntegrationBrokerController : ControllerBase
    {
        private readonly GecosIntegrationBrokerServiceClient _gecosService;
        private readonly IHttpClientFactory _httpClientFactory;

        public GecosIntegrationBrokerController(GecosIntegrationBrokerServiceClient gecosService, IHttpClientFactory clientFactory) 
        {
            _gecosService = gecosService;
            _httpClientFactory = clientFactory;
        }


        [HttpGet]
        public async Task<ActionResult<DataProduct>> GetDatosCaja([FromQuery] long idCaja)
        {
            var dataCaja = await _gecosService.GetProductDataAsync(idCaja, null, null, null, null);

            return (dataCaja == null) ? NotFound() : Ok(dataCaja);
        }

    }
}
