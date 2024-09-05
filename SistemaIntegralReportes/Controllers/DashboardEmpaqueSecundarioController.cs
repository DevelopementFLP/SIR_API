using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.Models;
using System;
using System.Data;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardEmpaqueSecundarioController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public HttpClient _httpClient;
        private string? _innovaConnectionString;
        private string? _sirConnectionString;
        private bool _connectionOK = false;

        public DashboardEmpaqueSecundarioController(HttpClient httpClient, IConfiguration configuration)
        {
            _innovaConnectionString = configuration.GetConnectionString("InnovaProduccion");
            _sirConnectionString = configuration.GetConnectionString("SqlTestConection");
            _connectionOK = _innovaConnectionString != null;
            _configuration = configuration;
        }
        
        #region Métodos síncronos
        #endregion

        #region Métodos asíncronos
        [HttpGet("GetLineasCajasAsync")]
        public async Task<IEnumerable<EstacionesCortesCajas>> GetLineasCajasAsync(int minutosDesde = 0)
        {
            var query = _configuration.GetSection("DashboardEmpaqueSecundario:SqlQueryCortesCajasXLinea").Value.ToString();

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.Open();

                    var filtro = minutosDesde == 0 ? " pack.prday = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' " : "pack.regtime between '" + DateTime.Now.AddMinutes(-minutosDesde).ToString("yyyy-MM-dd HH:mm:ss") + "'  and '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'"; ;
                    query = query.Replace("@filter", filtro);

                    var cajas = await sqlConnection.QueryAsync<EstacionesCortesCajas>(query, commandType: CommandType.Text);
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

        [HttpGet("GetEstacionesCortesCajasAsync")]
        public async Task<IEnumerable<EstacionesCortesCajas>> GetEstacionesCortesCajasAsync(int minutosDesde = 0)
        {
            var query = _configuration.GetSection("DashboardEmpaqueSecundario:SqlQueryCortesCajas").Value.ToString();

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.Open();

                    var filtro = minutosDesde == 0 ? " pack.prday = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' " : "pack.regtime between '" + DateTime.Now.AddMinutes(-minutosDesde).ToString("yyyy-MM-dd HH:mm:ss") + "'  and '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'"; ;
                    query = query.Replace("@filter", filtro);


                    var cajas = await sqlConnection.QueryAsync<EstacionesCortesCajas>(query, commandType: CommandType.Text);
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

        [HttpGet("GetEstacionesProcesoAsync")]
        public async Task<IEnumerable<EstacionProceso>> GetEstacionesProcesoAsync(int minutosDesde = 0)
        {
            var query = _configuration.GetSection("DashboardEmpaqueSecundario:SqlQueryEstacionesProceso").Value.ToString();

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    sqlConnection.Open();

                    var filtro = minutosDesde == 0 ? " pack.prday = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' " : "pack.regtime between '" + DateTime.Now.AddMinutes(-minutosDesde).ToString("yyyy-MM-dd HH:mm:ss") + "'  and '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    query = query.Replace("@filter", filtro);


                    var estaciones = await sqlConnection.QueryAsync<EstacionProceso>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return estaciones;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        sqlConnection.Close();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetCortesSinEmpacarAsync")]
        public async Task<IEnumerable<CortesSimEmpacar>> GetCortesSinEmpacarAsync()
        {
            var query = _configuration.GetSection("DashboardEmpaqueSecundario:SqlQueryCortesSinEmpacar").Value.ToString();

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    await sqlConnection.OpenAsync();

                    var filtro = " item.prday = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' ";
                    query = query.Replace("@filter", filtro);

                    var cortes = await sqlConnection.QueryAsync<CortesSimEmpacar>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return cortes;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        await sqlConnection.CloseAsync();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetCajasAbiertasAsync")]
        public async Task<IEnumerable<CajasAbiertas>> GetCajasAbiertasAsync()
        {
            var query = _configuration.GetSection("DashboardEmpaqueSecundario:SqlQueryCajasAbiertas").Value.ToString();

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    await sqlConnection.OpenAsync();

                    var filtro = " pack.prday = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' ";
                    query = query.Replace("@filter", filtro);

                    var cajasAbiertas = await sqlConnection.QueryAsync<CajasAbiertas>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return cajasAbiertas;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        await sqlConnection.CloseAsync();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetCajasCerradasAsync")]
        public async Task<IEnumerable<CajasCerradas>> GetCajasCerradasAsync()
        {
            var query = _configuration.GetSection("DashboardEmpaqueSecundario:SqlQueryCajasCerradas").Value.ToString();

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    await sqlConnection.OpenAsync();

                    var filtro = " pack.prday = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' ";
                    query = query.Replace("@filter", filtro);


                    var cajasCerradas = await sqlConnection.QueryAsync<CajasCerradas>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return cajasCerradas;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        await sqlConnection.CloseAsync();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetCajasTMSCerradasAsync")]
        public async Task<IEnumerable<CajasTMS>> GetCajasTMSCerradasAsync()
        {
            var query = _configuration.GetSection("DashboardEmpaqueSecundario:SqlQueryCajasTMSCerradas").Value.ToString();

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    await sqlConnection.OpenAsync();

                    var filtro = " pack.prday = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' ";
                    query = query.Replace("@filter", filtro);


                    var cajasTMS = await sqlConnection.QueryAsync<CajasTMS>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return cajasTMS;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        await sqlConnection.CloseAsync();

                    throw new Exception(e.Message);
                }
            }
        }


        [HttpGet("GetKilosTotalesAsync")]
        public async Task<int> GetKilosTotalesAsync()
        {
            var query = _configuration.GetSection("DashboardEmpaqueSecundario:SqlQueryKilosTotales").Value;

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return 0;

                try
                {
                    await sqlConnection.OpenAsync();

                    var filtro = " pack.prday = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' ";
                    query = query.Replace("@filter", filtro);


                    var kilos = await sqlConnection.QueryAsync<int>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return kilos.FirstOrDefault();
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        await sqlConnection.CloseAsync();
                    return 0;
                    //throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetProductosPorEstacionAsync")]
        public async Task<IEnumerable<ProductosPorEstacion>> GetProductosPorEstacionAsync(string station = "", int minutosDesde = 0)
        {
            var query = _configuration.GetSection("DashboardEmpaqueSecundario:SqlQueryProductStation").Value.ToString();

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    await sqlConnection.OpenAsync();

                    var st = "st.name in ('" + station + "')";

                    var filtro = minutosDesde == 0 ? " pack.prday = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' " : "pack.regtime between '" + DateTime.Now.AddMinutes(-minutosDesde).ToString("yyyy-MM-dd HH:mm:ss") + "'  and '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'"; ;

                    query = query.Replace("@filter", filtro).Replace("@station", st);

                    var productos = await sqlConnection.QueryAsync<ProductosPorEstacion>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return productos;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        await sqlConnection.CloseAsync();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetFechaPrimeraCajaAsync")]
        private async Task<DateTime?> GetFechaPrimeraCajaAsync(DateTime prday)
        {
            var query = _configuration.GetSection("DashboardEmpaqueSecundario:SqlQueryFechaPrimerCaja").Value;

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    await sqlConnection.OpenAsync();
                    DateTime dateF = new DateTime(prday.Year, prday.Month, prday.Day);
                    DateTime dateT = new DateTime(prday.Year, prday.Month, prday.Day);
                    DateTime dateFrom = dateF.AddMinutes(1);
                    DateTime dateTo = dateT.AddHours(23);

                    var filtro = " pack.regtime Between '" + dateFrom.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + dateTo.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                    query = query.Replace("@filter", filtro);

                    var fecha = await sqlConnection.QueryAsync<DateTime>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return fecha.FirstOrDefault();
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        await sqlConnection.CloseAsync();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetFechaUltimaCajaAsync")]
        private async Task<DateTime?> GetFechaUltimaCajaAsync(DateTime prday)
        {
            var query = _configuration.GetSection("DashboardEmpaqueSecundario:SqlQueryFechaUltimaCaja").Value;

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    await sqlConnection.OpenAsync();
                    DateTime dateF = new DateTime(prday.Year, prday.Month, prday.Day);
                    DateTime dateT = new DateTime(prday.Year, prday.Month, prday.Day);
                    DateTime dateFrom = dateF.AddMinutes(1);
                    DateTime dateTo = dateT.AddHours(23);

                    var filtro = " pack.regtime Between '" + dateFrom.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + dateTo.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
                    query = query.Replace("@filter", filtro);

                    var fecha = await sqlConnection.QueryAsync<DateTime>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return fecha.FirstOrDefault();
                }   
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        await sqlConnection.CloseAsync();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetPrimeraCajaWPLAsync")]
        public async Task<DateTime?> GetPrimeraCajaWPLAsync(DateTime prday, int idStation)
        {
            var query = _configuration.GetSection("DashboardEmpaqueSecundario:HoraPrimeraCajaWPL").Value;

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    await sqlConnection.OpenAsync();
                    DateTime dateF = new DateTime(prday.Year, prday.Month, prday.Day);
                    DateTime dateT = new DateTime(prday.Year, prday.Month, prday.Day);
                    DateTime dateFrom = dateF.AddMinutes(1);
                    DateTime dateTo = dateT.AddHours(23);

                    var filtro =  prday.ToString("yyyy-MM-dd");
                    query = query.Replace("@dateFilter", filtro).Replace("@idDevice", idStation.ToString());

                    var fecha = await sqlConnection.QueryAsync<DateTime>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return fecha.FirstOrDefault();
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        await sqlConnection.CloseAsync();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetUltimaCajaWPLAsync")]
        public async Task<DateTime?> GetUltimaCajaWPLAsync(DateTime prday, int idStation)
        {
            var query = _configuration.GetSection("DashboardEmpaqueSecundario:HoraUltimaCajaWPL").Value;

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    await sqlConnection.OpenAsync();
                    DateTime dateF = new DateTime(prday.Year, prday.Month, prday.Day);
                    DateTime dateT = new DateTime(prday.Year, prday.Month, prday.Day);
                    DateTime dateFrom = dateF.AddMinutes(1);
                    DateTime dateTo = dateT.AddHours(23);

                    var filtro = prday.ToString("yyyy-MM-dd");
                    query = query.Replace("@dateFilter", filtro).Replace("@idDevice", idStation.ToString());

                    var fecha = await sqlConnection.QueryAsync<DateTime>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return fecha.FirstOrDefault();
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        await sqlConnection.CloseAsync();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetCajasHoraAsync")]
        public async Task<IEnumerable<CajasHora>> GetCajasHoraAsync(DateTime prday)
        {
            var query = _configuration.GetSection("DashboardEmpaqueSecundario:SqlQueryCajasPorFecha").Value;
            CajasHora[] cajasPorHora = new CajasHora[] { };

            using (var sqlConnection = new SqlConnection(_innovaConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    await sqlConnection.OpenAsync();

                    DateTime fechaPrimeraCaja = (DateTime) await GetFechaPrimeraCajaAsync(prday);
                    DateTime fechaUltimaCaja = (DateTime) await GetFechaUltimaCajaAsync(prday);

                    DateTime fechaInicio = fechaPrimeraCaja;
                    DateTime fechaFin = fechaPrimeraCaja.AddMinutes(1);

                    while(fechaFin < fechaUltimaCaja)
                    {
                        var filtro = " pack.regtime BETWEEN '" + fechaInicio.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + fechaFin.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                        string nuevaQuery = query.Replace("@filter", filtro);
                        var cajasHora = await sqlConnection.QueryAsync<CajasHora>(nuevaQuery, commandType: CommandType.Text);
                        cajasPorHora = cajasPorHora.Concat(cajasHora).ToArray();
                        fechaInicio = fechaFin;
                        fechaFin = fechaFin.AddMinutes(1);
                    }


                    sqlConnection.Close();
                    return cajasPorHora;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        await sqlConnection.CloseAsync();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetTiemposActualizacionAsync")]
        public async Task<IEnumerable<TiempoActualizacion>> GetTiemposActualizacionAsync()
        {
            var query = _configuration.GetSection("DashboardEmpaqueSecundario:GetTiemposActualizacion").Value;

            using (var sqlConnection = new SqlConnection(_sirConnectionString))
            {
                if (sqlConnection == null) return null;

                try
                {
                    await sqlConnection.OpenAsync();

                    var tiempos = await sqlConnection.QueryAsync<TiempoActualizacion>(query, commandType: CommandType.Text);
                    sqlConnection.Close();
                    return tiempos;
                }
                catch (Exception e)
                {
                    if (sqlConnection != null)
                        await sqlConnection.CloseAsync();

                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetRefreshTime")]
        public string GetRefreshTime()
        {
            return _configuration.GetSection("DashboardEmpaqueSecundario:RefreshTimeInterval").Value.ToString();

        }
        #endregion
    }
}
