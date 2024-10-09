using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralReportes.DTO.Dispositivos;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.Servicios.Contrato.Dispositivos;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;
using SistemaIntegralReportes.Servicios.Implementacion;
using SistemaIntegralReportes.DTO.FichaTecnica;

namespace SistemaIntegralReportes.Controllers.FichaTecnica
{
    [Route("api/[controller]")]
    [ApiController]
    public class FtMarcaController : ControllerBase
    {
        private readonly IFtMarcas _FtMarcaServicio;

        //Creo el constructor del servicio
        public FtMarcaController(IFtMarcas ftMarcaServicio)
        {
            _FtMarcaServicio = ftMarcaServicio;
        }

        [HttpGet("ListaMarcasFichaTecnica")]
        public async Task<IActionResult> Lista()
        {
            var response = new ResponseDto<List<MarcaDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtMarcaServicio.Lista();
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("CrearMarcaFichaTecnica")]
        public async Task<IActionResult> Crear([FromBody] MarcaDTO modelo)
        {
            var response = new ResponseDto<MarcaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtMarcaServicio.Crear(modelo);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("EditarMarcaFichaTecnica")]
        public async Task<IActionResult> Editar([FromBody] MarcaDTO modelo)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtMarcaServicio.Editar(modelo);
                response.Mensaje = response.EsCorrecto ? "Marca editada con éxito." : "No se pudo editar la marca.";
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("EliminarMarcaFichaTecnica/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _FtMarcaServicio.Eliminar(id);
                response.Mensaje = response.EsCorrecto ? "Marca eliminada con éxito." : "No se pudo eliminar la marca.";
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
