using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.Models;
using System.Data;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControlCalidadController : ControllerBase
    {
        public HttpClient? _httpClient;
        private readonly IConfiguration _configuration;
        private string? _sirConnectionString;

        public ControlCalidadController(IConfiguration configuration)
        {
            _sirConnectionString = configuration.GetConnectionString("SqlTestConection");
            _configuration = configuration;
        }

        #region Método asíncronos
        [HttpPost("InsertOrdinalesPhAsync")]
        public async Task<IActionResult> InsertOrdinalesPhAsync([FromBody] List<OrdinalPH> rechazados)
        {

            var query = _configuration.GetSection("ControlCalidad:InsertarRechazoPH").Value;

            using (var sqlConnection = new SqlConnection(_sirConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    await sqlConnection.OpenAsync();

                    foreach(var item in rechazados)
                    {
                        var currentQuery = query;
                        currentQuery = currentQuery.Replace("@ordinalNro", item.OrdinalNro.ToString());
                        currentQuery = currentQuery.Replace("@fechaFaena", item.FechaFaena.ToString("yyyy-MM-dd"));

                        await sqlConnection.QueryAsync(currentQuery, commandType: CommandType.Text);
                    }

                    sqlConnection.Close();
                    return Ok();
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        await sqlConnection.CloseAsync();

                    throw new Exception(e.Message);
                }
            }
        }
        #endregion
    }
}
