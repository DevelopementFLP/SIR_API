using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.Cuota;
using System.Configuration;
using System.Data;

namespace SistemaIntegralReportes.Controllers.Cuota
{
    [Route("api/[controller]")]
    [ApiController]
    public class CajaLoteController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _innovaConnectionString;

        public CajaLoteController(IConfiguration configuration)
        {
            _configuration = configuration;
            _innovaConnectionString = configuration.GetConnectionString("InnovaProduccion");
        }

        [HttpGet("GetLotesEntradaAsync")]
        public async Task<IEnumerable<SalidaDTO>> GetLotesEntradaAsync(DateTime fechaProduccion, string lotes)
        {
            var storedProcedure = _configuration.GetSection("ReporteCuota:CajasPorLoteYFecha").Value;

            using (var connection = new SqlConnection(_innovaConnectionString))
            {
                if (connection == null) return Enumerable.Empty<SalidaDTO>();

                try
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@fechaProduccion", fechaProduccion, DbType.DateTime);
                    parameters.Add("@lotes", lotes, DbType.String);

                    var cajas = await connection.QueryAsync<SalidaDTO>(storedProcedure, parameters, commandType: CommandType.Text);

                    return cajas;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al ejecutar el procedimiento almacenado: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

        }
    }
}
