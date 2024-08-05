using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.Models;
using SistemaIntegralReportes.Models.Dispositivos;
using SistemaIntegralReportes.Servicios.Contrato;

namespace SistemaIntegralReportes.Controllers.Dispositivos
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispositivoController : ControllerBase
    {
        //Creao el servicio
        private readonly IDispositivo _dispositivoServicio;

        //Creo el constructor del servicio
        public DispositivoController(IDispositivo dispositivoServicio)
        {
            _dispositivoServicio = dispositivoServicio;
        }

        [HttpGet("ListaDispositivos/{buscar:alpha?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDto<List<DispositivosDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.EsCorrecto = true;
                response.Resultado = await _dispositivoServicio.Lista(buscar);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        [HttpGet("filtrarDispositivos/{Id:int}")]

        public async Task<IActionResult> Buscar(int Id)
        {
            var response = new ResponseDto<DispositivosDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _dispositivoServicio.Buscar(Id);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("crearDispositivos")]
        public async Task<IActionResult> Crear([FromBody] DispositivosDTO modelo)
        {
            var response = new ResponseDto<DispositivosDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _dispositivoServicio.Crear(modelo);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("actualizarDispositivos")]

        public async Task<IActionResult> Editar([FromBody] DispositivosDTO modelo)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _dispositivoServicio.Editar(modelo);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("eliminarDispositivo/{Id:int}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _dispositivoServicio.Eliminar(Id);

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
