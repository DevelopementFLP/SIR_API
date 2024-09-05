using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.Models;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesosReportesController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public HttpClient _httpClient;
        private string? _innovaConnectionString;
        private string? _sirConnectionString;
        private bool _connectionOK = false;

        public AccesosReportesController(IConfiguration configuration)
        {
            _innovaConnectionString = configuration.GetConnectionString("InnovaProduccion");
            _sirConnectionString = configuration.GetConnectionString("SqlTestConection");
            _connectionOK = _innovaConnectionString != null;
            _configuration = configuration;
        }

        #region Métodos asíncronos
        [HttpGet("GetAccesosReportesAsync")]
        public async Task<IEnumerable<AccesoReporte>> GetAccesosReportesAsync(int idUsuario)
        {
            {
                var query = _configuration.GetSection("Accesos:AccesosReportes").Value.ToString();

                using(var connection = new SqlConnection(_sirConnectionString))
                {
                    if (connection == null) return null;
                    try
                    {
                        connection.Open();
                        query = query.Replace("@idUsuario", idUsuario.ToString());
                        var reportes = await connection.QueryAsync<AccesoReporte>(query, commandType: System.Data.CommandType.Text);
                        connection.Close();
                        return reportes;
                    }
                    catch (Exception e)
                    {
                        if(connection != null)
                            connection.Close();
                        throw new Exception(e.Message);
                    }
                }
            }

            #endregion
        }
    }
}
