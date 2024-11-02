using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralReportes.DTO.FichaTecnica;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;

namespace SistemaIntegralReportes.Controllers.FichaTecnica
{
    [Route("api/[controller]")]
    [ApiController]
    public class FtIdiomasController : ControllerBase
    {
        private readonly IFtIdioma _FtIdiomaServicio;

        //Creo el constructor del servicio
        public FtIdiomasController(IFtIdioma ftIdiomaServicio)
        {
            _FtIdiomaServicio = ftIdiomaServicio;
        }

        [HttpGet("ListaIdiomasFichaTecnica")]
        public async Task<IActionResult> Lista()
        {
            var response = new ResponseDto<List<IdiomaDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _FtIdiomaServicio.Lista();
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
