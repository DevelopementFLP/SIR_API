using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.Models.Reportes;
using SistemaIntegralReportes.Servicios.Contrato;
using SistemaIntegralReportes.Servicios.Implementacion;

namespace SistemaIntegralReportes.Controllers.Dispositivos
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaDeCajasController : ControllerBase
    {
        private readonly IListaDeCajas _listaDeCajasServicio;

        //Creo el constructor del servicio
        public ListaDeCajasController(IListaDeCajas listaDeCajasServicio)
        {
            _listaDeCajasServicio = listaDeCajasServicio;
        }

        [HttpGet("listaDeLecturas/{Id:int}")]
        public async Task<IActionResult> BuscarListaDeLecturas(string Id)
        {
            var response = new ResponseDto<List<ListaDeCajas>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _listaDeCajasServicio.BuscarListaDeLecturas(Id);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("listaDeExpoCarga/{Id:int}")]
        public async Task<IActionResult> BuscarListaDeExportaciones(string Id)
        {
            var response = new ResponseDto<List<ListaDeCajas>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _listaDeCajasServicio.BuscarListaDeExportaciones(Id);

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
