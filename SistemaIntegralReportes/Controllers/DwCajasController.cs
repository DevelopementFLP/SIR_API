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
    public class DwCajasController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public HttpClient _httpClient;
        private string? _innovaConnectionString;
        private string? _sirConnectionString;
        private bool _connectionOK = false;

        public DwCajasController(IConfiguration configuration)
        {
            _innovaConnectionString = configuration.GetConnectionString("InnovaProduccion");
            _sirConnectionString = configuration.GetConnectionString("SqlTestConection");
            _connectionOK = _innovaConnectionString != null;
            _configuration = configuration;
        }

        #region Métodos asíncronos
        [HttpGet("GetCajasDW")]
        public async Task<IEnumerable<DwCajas>> GetCajasDW(string fechaProducidoDesde, string fechaProducidoHasta)
        {
            var query = _configuration.GetSection("DWCajas:SelectDWCajas").Value.ToString();

            using (var sqlConnection = new SqlConnection(_sirConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.Open();

                    query = query.Replace("@fechaProducidoDesde", fechaProducidoDesde.ToString()).Replace("@fechaProducidoHasta", fechaProducidoHasta.ToString());

                    var cajas = await sqlConnection.QueryAsync<DwCajas>(query, commandType: CommandType.Text);
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

        #endregion
    }
}
