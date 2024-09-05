using Microsoft.AspNetCore.Mvc;
using SistemaIntegralReportes.Models;
using SistemaIntegralReportes.Servicios;
using Microsoft.AspNetCore.Cors;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AnimalHaciendaController : ControllerBase
    {
        private readonly AnimalHaciendaService _haciendaService;


        public AnimalHaciendaController(AnimalHaciendaService haciendaService)
        {
            _haciendaService = haciendaService;   
        }

        [HttpGet("getAnimalesHacienda")]
        public async Task<ActionResult<AnimalHacienda>> GetAnimalFaena([FromQuery] DateTime fechaDeFaena)
        {
            var animalFaenaData = await _haciendaService.GetHaciendaData<AnimalHacienda>(fechaDeFaena);
            
            return (animalFaenaData == null) ? NotFound() : Ok(animalFaenaData);
        }
    }
}
