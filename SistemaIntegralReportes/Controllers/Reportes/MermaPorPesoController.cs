using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.Models.Reportes;
using SistemaIntegralReportes.Servicios.Contrato;
using SistemaIntegralReportes.Servicios.Implementacion;

namespace SistemaIntegralReportes.Controllers.Reportes
{
    [Route("api/[controller]")]
    [ApiController]
    public class MermaPorPesoController : ControllerBase
    {
        private readonly IMermaPorPeso _listaDeMermasPorPeso;

        //Creo el constructor del servicio
        public MermaPorPesoController(IMermaPorPeso listaDeMermasPorPeso)
        {
            _listaDeMermasPorPeso = listaDeMermasPorPeso;
        }

        [HttpGet("listaDeMermasPorPeso")]
        public async Task<IActionResult> BuscarListaDeLecturas(string FechaDesde, string FechaHasta)
        {
            var response = new ResponseDto<List<MermaPorPeso>>();
           
            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _listaDeMermasPorPeso.BuscarListaDeMermasPorPeso(FechaDesde, FechaHasta);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

    }
}
