using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.DTO.FichaTecnica;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;

namespace SistemaIntegralReportes.Controllers.FichaTecnica
{
    [Route("api/[controller]")]
    [ApiController]
    public class FtFichaTecnicaController : ControllerBase
    {
        private readonly IFtFichaTecnica _FtFichaTecnicaServicio;

        public FtFichaTecnicaController(IFtFichaTecnica ftFichaTecnicaServicio)
        {
            _FtFichaTecnicaServicio = ftFichaTecnicaServicio;
        }

        [HttpGet("ListaDeFichasTecnicas")]
        public async Task<IActionResult> ListaDeFichasTecnicas()
        {
            var response = new ResponseDto<List<FichaTecnicaDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtFichaTecnicaServicio.ListaDeFichasTecnicas();
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        // Método para crear una ficha técnica
        [HttpPost("CrearFichaTecnica")]
        public async Task<IActionResult> Crear([FromBody] FichaTecnicaDTO modelo)
        {
            var response = new ResponseDto<FichaTecnicaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtFichaTecnicaServicio.Crear(modelo);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("BuscarFichaTecnica")]
        public async Task<IActionResult> Buscar(string codigoDeProducto)
        {
            var response = new ResponseDto<List<FichaTecnicaDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtFichaTecnicaServicio.Buscar(codigoDeProducto);

                // Verificar si no se encontraron resultados
                if (response.Resultado == null || !response.Resultado.Any())
                {
                    response.EsCorrecto = false;
                    response.Mensaje = "No se encontró ficha técnica.";
                }
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("EditarFichaTecnica")]
        public async Task<IActionResult> Editar([FromBody] FichaTecnicaDTO modelo)
        {
            var response = new ResponseDto<FichaTecnicaDTO>();

            try
            {
                var resultado = await _FtFichaTecnicaServicio.Editar(modelo);

                if (resultado)
                {
                    response.EsCorrecto = true;
                    response.Resultado = modelo; 
                }
                else
                {
                    response.EsCorrecto = false;
                    response.Mensaje = "No se pudo editar la ficha técnica.";
                }
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        [HttpDelete("EliminarFichaTecnica")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDto<bool>();

            try
            {
                var resultado = await _FtFichaTecnicaServicio.Eliminar(id);

                if (resultado)
                {
                    response.EsCorrecto = true;
                    response.Resultado = true; 
                }
                else
                {
                    response.EsCorrecto = false;
                    response.Mensaje = "No se pudo eliminar la ficha técnica.";
                }
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
