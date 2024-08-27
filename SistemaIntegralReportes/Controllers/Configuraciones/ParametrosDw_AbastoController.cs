using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.Models.Configuraciones;
using SistemaIntegralReportes.Servicios.Contrato;
using SistemaIntegralReportes.Servicios.Contrato.Abasto;

namespace SistemaIntegralReportes.Controllers.Configuraciones
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametrosDw_AbastoController : ControllerBase
    {
        private readonly IConfiguracionAbasto _listaDeParametros;

        //Creo el constructor del servicio
        public ParametrosDw_AbastoController(IConfiguracionAbasto listaDeParametrosAbasto)
        {
            _listaDeParametros = listaDeParametrosAbasto;
        }

        [HttpGet("GetParametrosSeccionAbasto")]
        public async Task<IActionResult> ListaDeParametrosAbasto()
        {
            var response = new ResponseDto<List<ParametrosDw_Abasto>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _listaDeParametros.GetParametrosSeccionAbasto();

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
