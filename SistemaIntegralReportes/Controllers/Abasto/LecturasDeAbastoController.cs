﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.DTO.Abasto;
using SistemaIntegralReportes.Models.Reportes;
using SistemaIntegralReportes.Models.Reportes.ReporteAbasto;
using SistemaIntegralReportes.Servicios.Contrato;
using SistemaIntegralReportes.Servicios.Contrato.Abasto;

namespace SistemaIntegralReportes.Controllers.Abasto
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturasDeAbastoController : ControllerBase
    {
        private readonly ILecturaDeAbasto _lecturaDeMedia;

        public LecturasDeAbastoController(ILecturaDeAbasto lecturaDeAbasto)
        {
            _lecturaDeMedia = lecturaDeAbasto;
        }

        [HttpGet("getListaDeLecturas")]
        public async Task<IActionResult> GetLecturaDeAbasto()
        {
            var response = new ResponseDto<List<LecturaDeAbastoDTO>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _lecturaDeMedia.GetLecturaDeAbasto();

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        [HttpGet("insertarLecturaDeMedia")]
        public async Task<IActionResult> InsertarLecturaDeAbasto(string lecturaDeAbasto, string operacion, string usuarioLogueado, DateTime? fechaDeFaena)
        {
            var response = new ResponseDto<LecturaDeAbastoDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _lecturaDeMedia.InsertarLectura(lecturaDeAbasto, operacion, usuarioLogueado, fechaDeFaena);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("listadoStockDeAbasto")]
        public async Task<IActionResult> ListarStockAbasto()
        {
            var response = new ResponseDto<List<ListaDeLecturasAbasto>>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _lecturaDeMedia.ListarStockAbasto();

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("getLecturaDeQr")]
        public async Task<IActionResult> getLecturaQr(string codigoQr)
        {
            var response = new ResponseDto<LecturaDeAbastoDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _lecturaDeMedia.GetCodigoQrFiltrado(codigoQr);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        // Método para eliminar una lectura de abasto
        [HttpDelete("eliminarLectura")]
        public async Task<IActionResult> DeleteLecturaDeAbasto(string idAnimal)
        {
            var response = new ResponseDto<bool>();

            try
            {
                response.EsCorrecto = await _lecturaDeMedia.DeleteLecturaDeAbasto(idAnimal);
                if (response.EsCorrecto)
                {
                    response.Mensaje = "Lectura eliminada exitosamente.";
                }
                else
                {
                    response.Mensaje = "No se pudo eliminar la lectura.";
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
