using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralReportes.DTO.Abasto;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.Servicios.Contrato.Abasto;
using SistemaIntegralReportes.Servicios.Contrato.Cajas;
using SistemaIntegralReportes.DTO.Cajas;

namespace SistemaIntegralReportes.Controllers.Cajas
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentificadorDeCajasController : ControllerBase
    {
        private readonly IIdentificacionDeCajas _resultado;

        public IdentificadorDeCajasController(IIdentificacionDeCajas resultadoDeBusqueda)
        {
            _resultado = resultadoDeBusqueda;
        }

        [HttpGet("getResultadoDeCaja")]
        public async Task<IActionResult> GetLecturaDeAbasto(string codigoDeCaja)
        {
            var response = new ResponseDto<IdentificadorDeCajasDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _resultado.getLecturaDeCaja(codigoDeCaja);

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
