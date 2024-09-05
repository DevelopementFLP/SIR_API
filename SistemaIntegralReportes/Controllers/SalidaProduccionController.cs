using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralReportes.Models;
using SistemaIntegralReportes.Servicios;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SalidaProduccionController : ControllerBase
    {
        private readonly SalidaProduccionService _produccionService;

        public SalidaProduccionController(SalidaProduccionService produccionService)
        {
            _produccionService = produccionService;
        }

        [HttpGet("salidasProduccion")]
        public async Task<ActionResult<AnimalHacienda>> SalidasProduccion([FromQuery] DateTime fechaDeProduccion)
        {
            var salidas = await _produccionService.GetProduccionData<SalidaProduccion>(fechaDeProduccion);

            return (salidas == null) ? NotFound() : Ok(salidas); 
        }

        [HttpGet("salidasProduccionConFiltro")]
        public async Task<CajasKilosGecos> SalidasProduccionConFiltro([FromQuery] DateTime fechaDesde, [FromQuery] DateTime fechaHasta, [FromQuery] string filtro)
        {
            var cajasKilos = new CajasKilosGecos();
            var salidas = await _produccionService.GetProduccionDataConFiltro<SalidaProduccionGecos>(fechaDesde, fechaHasta, filtro);

            if (salidas != null)
            {
                cajasKilos.Kilos = SumarPesos(salidas.Where(p => !p.CodProceso.Contains("REPROC")));
                cajasKilos.Cajas = salidas.Where(p => !p.CodProceso.Contains("REPROC")).Count();
            }

            return cajasKilos;
        }

        private double SumarPesos(IEnumerable<SalidaProduccionGecos> salidas)
        {
            double suma = 0;
            foreach (var producto in salidas)
                suma += producto.PesoBruto;

            return suma;
        }

        [HttpGet("GetCajasGecos")]
        public async Task<ActionResult<IEnumerable<SalidaProduccion>>> GetCajasGecos(DateTime fechaProduccion)
        {
            var salidas = await _produccionService.GetProduccionData<SalidaProduccion>(fechaProduccion);

            return (salidas == null) ? NotFound() : Ok(salidas);
        }


    }
}
