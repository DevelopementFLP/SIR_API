using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralReportes.Models;
using SistemaIntegralReportes.Servicios;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class FanaTipificacionChileController : ControllerBase
    {
        private readonly FaenaTipificacionChileService _faenaService;

        public FanaTipificacionChileController(FaenaTipificacionChileService faenaService)
        {
            _faenaService = faenaService;
        }


        [HttpGet("getTipificacionChile")]
        public async Task<ActionResult<TipificacionChile>> GetAnimalFaena([FromQuery] DateTime fechaDeFaena)
        {
            var tipificacion = await _faenaService.GetFaenaData<TipificacionChile>(fechaDeFaena); //await _animalFaenaService.GetAnimalFaenaData(fechaDeFaena);

            return (tipificacion == null) ? NotFound() : Ok(tipificacion);
        }
    }
}
