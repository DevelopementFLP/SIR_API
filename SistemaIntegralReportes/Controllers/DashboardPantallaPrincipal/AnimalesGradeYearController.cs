using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.Cuota;
using SistemaIntegralReportes.DTO.DashboardPantallaPrincipal;
using System.Data;

namespace SistemaIntegralReportes.Controllers.DashboardPantallaPrincipal
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalesGradeYearController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _sirConnectionString;

        public AnimalesGradeYearController(IConfiguration configuration)
        {
            _configuration = configuration;
            _sirConnectionString = configuration.GetConnectionString("SqlTestConection");
        }

        [HttpGet("GetAnimalesGradeYearAsync")]
        public async Task<IEnumerable<AnimalesGradeYear>> GetAnimalesGradeYearAsync()
        {
            var query = _configuration.GetSection("DashboardPantallaPrincipal:AnimalesGradeYear").Value;
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return Enumerable.Empty<AnimalesGradeYear>();

                try
                {
                    connection.Open();
                    var animales = await connection.QueryAsync<AnimalesGradeYear>(query, commandType: CommandType.Text);
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
