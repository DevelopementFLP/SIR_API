using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralReportes.Models;
using SistemaIntegralReportes.Servicios;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class TipificacionHaciendaController : ControllerBase
    {
        private readonly TipificacionHaciendaService _tipificacionFaenaService;

        public TipificacionHaciendaController(TipificacionHaciendaService tipificacionFaenaService)
        {
            _tipificacionFaenaService = tipificacionFaenaService;
        }

        [HttpGet("getTipificacionFaena")]
        public async Task<ActionResult<TipificacionHacienda>> GetTipificacionFaena([FromQuery] DateTime fechaDeFaena)
        {
            var tipificacionData = await _tipificacionFaenaService.GetHaciendaData<TipificacionHacienda>(fechaDeFaena);

            return (tipificacionData == null) ? NotFound() : Ok(tipificacionData);
        }
    }
}
