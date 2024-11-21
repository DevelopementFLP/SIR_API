using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.DashboardPantallaPrincipal;
using System.Data;

namespace SistemaIntegralReportes.Controllers.DashboardPantallaPrincipal
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalesFaenadosController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _sirConnectionString;

        public AnimalesFaenadosController(IConfiguration configuration)
        {
            _configuration = configuration;
            _sirConnectionString = configuration.GetConnectionString("SqlTestConection");
        }

        [HttpGet("GetAnimalesFaenadosAsync")]
        public async Task<IEnumerable<AnimalesFaenadosDay>> GetAnimalesFaenadosAsync()
        {
            var query = _configuration.GetSection("DashboardPantallaPrincipal:AnimalesFaenados").Value;
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return Enumerable.Empty<AnimalesFaenadosDay>();

                try
                {
                    connection.Open();
                    var animales = await connection.QueryAsync<AnimalesFaenadosDay>(query, commandType: CommandType.Text);
                    return animales;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al ejecutar la consulta: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
