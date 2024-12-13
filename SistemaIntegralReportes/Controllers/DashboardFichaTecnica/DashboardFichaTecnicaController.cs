using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.DashboardFichaTecnica;
using System.Data;

namespace SistemaIntegralReportes.Controllers.DashboardFichaTecnica
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardFichaTecnicaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _innovaConnectionString;

        public DashboardFichaTecnicaController(IConfiguration configuration)
        {
            _configuration = configuration;
            _innovaConnectionString = configuration.GetConnectionString("InnovaProduccion");
        }

        [HttpGet("GetProductosActivosAsync")]
        public async Task<IEnumerable<ProductoActivo>> GetProductosActivosAsync()
        {
            var query = _configuration.GetSection("DashboardFichaTecnica:GetProductosOrdenesActivas").Value.ToString();
            if (query == null) return Enumerable.Empty<ProductoActivo>();

            using (var connection = new SqlConnection(_innovaConnectionString))
            {
                if (connection == null) return Enumerable.Empty<ProductoActivo>();

                try
                {
                    await connection.OpenAsync();
                    var productosActivos = await connection.QueryAsync<ProductoActivo>(query, commandType:CommandType.Text);
                    return productosActivos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al ejecutar la consulta: " + e.Message);
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }

        [HttpGet("GetTiempoProductoActivo")]
        public int GetTiempoProductoActivo()
        {
            int defaultTime = 5000;

            var time = _configuration.GetSection("DashboardFichaTecnica:TiempoProductoActivo").Value.ToString();
            
            if (time == null) return defaultTime;

            return int.Parse(time);
            
        }

        [HttpGet("GetTiempoActualizacionDashboard")]
        public int GetTiempoActualizacionDashboard()
        {
            int defaultTime = 300000;
            var time = _configuration.GetSection("DashboardFichaTecnica:TiempoActualizacionDashboard").Value.ToString();
            if (time == null) return defaultTime; 
            return int.Parse(time);
        }
    }
}
