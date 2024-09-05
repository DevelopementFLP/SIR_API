using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.Models;
using System.Configuration;
using System.Data;
using Dapper;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public HttpClient _httpClient;
        private string? _innovaConnectionString;
        private string? _sirConnectionString;
        private bool _connectionOK = false;

        public MantenimientoController(IConfiguration configuration) {

            _innovaConnectionString = configuration.GetConnectionString("InnovaProduccion");
            _sirConnectionString = configuration.GetConnectionString("SqlTestConection");
            _connectionOK = _innovaConnectionString != null;
            _configuration = configuration;
        }

        #region Métodos asíncronos
        [HttpGet("GetCabezasFaenadas")]
        public async Task<IEnumerable<CabezaFaenada>> GetCabezasFaenadas(string fechaFaenaDesde, string fechaFaenaHasta)
        {
            var query = _configuration.GetSection("Mantenimiento:CabezasFaenadas").Value.ToString();

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.Open();

                    query = query.Replace("@fechaFaenaDesde", fechaFaenaDesde).Replace("@fechaFaenaHasta", fechaFaenaHasta);

                    var cajas = await sqlConnection.QueryAsync<CabezaFaenada>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return cajas;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        sqlConnection.Close();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetTemperaturasCamaras910")]
        public async Task<IEnumerable<DataTemperatura>> GetTempraturasCamaras910(string fechaDesde, string fechaHasta)
        {
            var query = _configuration.GetSection("Mantenimiento:TemperaturaC9C10").Value.ToString();
            using(var sqlConnection = new SqlConnection(_sirConnectionString))
            {
                if (sqlConnection == null) return null;
                try
                {
                    sqlConnection.Open();
                    query = query.Replace("@fechaDesde", fechaDesde).Replace("@fechaHasta", fechaHasta);
                    var temps = await sqlConnection.QueryAsync<DataTemperatura>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return temps;
                }
                catch (Exception e)
                {
                    if(sqlConnection != null)
                        sqlConnection.Close();
                    throw new Exception(e.Message);
                }
            }
        }
        #endregion
    }
}
