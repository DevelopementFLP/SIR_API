using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralReportes.Models;
using SistemaIntegralReportes.Servicios;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class LoteHaciendaController : ControllerBase
    {
        private readonly LoteHaciendaService _loteFaenaService;

        public LoteHaciendaController(LoteHaciendaService loteFaenaService)
        {
            _loteFaenaService = loteFaenaService;
        }

        [HttpGet("getLotesHacienda")]
        public async Task<ActionResult<LoteHacienda>> GetAnimalFaena([FromQuery] DateTime fechaDeFaena)
        {
            var animalFaenaData = await _loteFaenaService.GetHaciendaData<LoteHacienda>(fechaDeFaena);

            return (animalFaenaData == null) ? NotFound() : Ok(animalFaenaData);
        }
    }
}
