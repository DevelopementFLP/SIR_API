using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.AplicacionDePedidos.Entidades;
using SistemaIntegralReportes.DTO.Carga;
using SistemaIntegralReportes.Models;
using SistemaIntegralReportes.Models.StockCajas;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportacionesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private string? _sirConnectionString;
        private string? _innovaConnectionString;
        public ExportacionesController(IConfiguration configuration)
        {
            _sirConnectionString = configuration.GetConnectionString("SqlTestConection");
            _innovaConnectionString = configuration.GetConnectionString("InnovaConnectionString");
            _configuration = configuration;
        }

        #region Métodos síncronos
        #endregion

        #region Métodos asíncronos
        [HttpGet("GetContainersAsync")]
        public async Task<IEnumerable<string>?> GetContainersAsync()
        {
            var query = _configuration.GetSection("Exportaciones:GetContainers").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();

                    var containers = await connection.QueryAsync<string>(query, commandType: CommandType.Text);
                    connection.Close();
                    return containers;
                }
                catch (Exception e)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetIdCargaContainersAsync")]
        public async Task<IEnumerable<ContainerDTO>?> GetIdCargaContainersAsync()
        {
            var query = _configuration.GetSection("Exportaciones:GetContainers").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();

                    var containers = await connection.QueryAsync<ContainerDTO>(query, commandType: CommandType.Text);
                    connection.Close();
                    return containers;
                }
                catch (Exception e)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetDataByContainersAsync")]
        public async Task<IEnumerable<DWContainer>?> GetDataByContainersAsync(string idsCarga, string containers)
        {
            var query = _configuration.GetSection("Exportaciones:GetDataByContainer").Value.ToString();
            var filterContainers = "";
            var conts = containers.Split(',');

            foreach (var container in conts)
            {
                var c = container.Trim();
                filterContainers += "'" + c + "',";
            }

            filterContainers = filterContainers.Substring(0, filterContainers.Length - 1);

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();
                    query = query.Replace("@filter", filterContainers).Replace("@idCarga", idsCarga);
                    var data = await connection.QueryAsync<DWContainer>(query, commandType: CommandType.Text);
                    connection.Close();
                    return data;
                }
                catch (Exception e)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetTipoMonedaAsync")]
        public async Task<IEnumerable<ConfMoneda>> GetTipoMonedaAsync()
        {
            var query = _configuration.GetSection("Exportaciones:GetTiposMoneda").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();

                    var tiposMonedas = await connection.QueryAsync<ConfMoneda>(query, commandType: CommandType.Text);
                    connection.Close();
                    return tiposMonedas;
                }
                catch (Exception e)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetPreciosPorFechaAsync")]
        public async Task<IEnumerable<ConfPrecioDTO>> GetPreciosPorFechaAsync(string fechaDesde, string fechaHasta)
        {
            var query = _configuration.GetSection("Exportaciones:GetPreciosPorFechas").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();

                    query = query.Replace("@fechaDesde", fechaDesde).Replace("@fechaHasta", fechaHasta);

                    var precios = await connection.QueryAsync<ConfPrecioDTO>(query, commandType: CommandType.Text);
                    connection.Close();
                    return precios;
                }
                catch (Exception e)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetPreciosAsync")]
        public async Task<IEnumerable<ConfPrecioDTO>> GetPreciosAsync()
        {
            var query = _configuration.GetSection("Exportaciones:GetPrecios").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();

                    var precios = await connection.QueryAsync<ConfPrecioDTO>(query, commandType: CommandType.Text);
                    connection.Close();
                    return precios;
                }
                catch (Exception e)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        [HttpDelete("DeleteListasPreciosAsync")]
        public async Task DeleteListasPreciosAsync([FromBody] string[] fechas)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null)
                {
                    return;
                }

                try
                {
                    int rowsAffected = 0;
                    await connection.OpenAsync();

                    var query = _configuration.GetSection("Exportaciones:DeleteListaPrecios").Value.ToString();

                    foreach (string fecha in fechas)
                    {
                        var q = query.Replace("@fecha", fecha);

                        using (var command = new SqlCommand(q, connection))
                        {

                            rowsAffected += await command.ExecuteNonQueryAsync();
                        }
                    }

                }
                catch (Exception ex)
                {
                }
            }
        }

        [HttpPost("InsertListaPreciosAsync")]
        public async Task InsertListaPreciosAsync([FromBody] List<ConfPrecio> precios)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return;
                try
                {
                    connection.Open();
                    foreach (ConfPrecio precio in precios)
                    {
                        var query = _configuration.GetSection("Exportaciones:InsertListaPrecios").Value.ToString();
                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@fecha_produccion", precio.Fecha_Produccion);
                            command.Parameters.AddWithValue("@codigo_producto", precio.Codigo_Producto);
                            command.Parameters.AddWithValue("@precio_tonelada", precio.Precio_Tonelada);
                            command.Parameters.AddWithValue("@fecha_registro", precio.Fecha_Registro);
                            command.Parameters.AddWithValue("@id_usuario", precio.Id_Usuario);
                            command.Parameters.AddWithValue("@id_moneda", precio.Id_Moneda);
                            await command.ExecuteNonQueryAsync();

                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    if (connection != null) connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("GetPrecioToneladaCodigoFechaAsync")]
        public async Task<double> GetPrecioToneladaCodigoFechaAsync(string codigo, DateTime fecha)
        {

            var query = _configuration.GetSection("Exportaciones:GetCodigoPrecioFecha").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return 0;

                try
                {
                    connection.Open();

                    query = query.Replace("@codigoProducto", codigo).Replace("@fechaProduccion", fecha.ToString("yyyy-MM-dd"));

                    var precio = await connection.QueryFirstOrDefaultAsync<double>(query, commandType: CommandType.Text);
                    connection.Close();
                    return precio;
                }
                catch (Exception e)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        [HttpPut("UpdateCodigoPreciosAsync")]
        public async Task UpdateCodigoPreciosAsync([FromBody] List<CodigoFechaPrecios> codigosPrecios)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return;

                try
                {
                    connection.Open();
                    foreach (var codigo in codigosPrecios)
                    {
                            var query = _configuration.GetSection("Exportaciones:UpdateCodigoPrecio").Value.ToString();
                            using (var command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@codigoProducto", codigo.Codigo);
                                command.Parameters.AddWithValue("@fechaProduccion", codigo.FechaProduccion.ToString("yyyy-MM-dd"));
                                command.Parameters.AddWithValue("@precioTonelada", codigo.Precio);

                                await command.ExecuteNonQueryAsync();
                            }
                        
                    }
                    
                    connection.Close();
                }
                catch (Exception ex)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("GetFechasAsync")]
        public async Task<IEnumerable<DateTime>> GetFechasAsync()
        {
            var query = _configuration.GetSection("Exportaciones:GetFechas").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();

                    var fechas = await connection.QueryAsync<DateTime>(query, commandType: CommandType.Text);
                    connection.Close();
                    return fechas;
                }
                catch (Exception e)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetCajasCargaAsync")]
        public async Task<IEnumerable<DWCajaCarga>> GetCajasCargaAsync(string idsCarga, string containerList)
        {
            var query = _configuration.GetSection("Exportaciones:GetDWCajasCarga").Value.ToString();
            var filterContainers = "";
            var conts = containerList.Split(',');

            foreach (var container in conts)
            {
                var c = container.Trim();
                filterContainers += "'" + c + "',";
            }

            filterContainers = filterContainers.Substring(0, filterContainers.Length - 1);

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();
                    query = query.Replace("@filter", filterContainers).Replace("@idCarga", idsCarga);
                    var cajasCarga = await connection.QueryAsync<DWCajaCarga>(query, commandType: CommandType.Text);
                    connection.Close();
                    return cajasCarga;
                }
                catch (Exception e)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }


        #region ConfProductos

        [HttpGet("GetConfiguracionProductoKosherAsync")]
        public async Task<IEnumerable<ConfiguracionProductoKosherDTO>> GetConfiguracionProductoKosherAsync()
        {
            var query = _configuration.GetSection("Exportaciones:GetConfiguracionPrdoductoKosher").Value.ToString();

            using(var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();
                    var productos = await connection.QueryAsync<ConfiguracionProductoKosherDTO>(query, commandType: CommandType.Text);
                    connection.Close();
                    return productos;
                }
                catch (Exception ex)
                {
                    if(connection != null) connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("GetConfProductosAsync")]
        public async Task<IEnumerable<ConfProducto>> GetConfProductosAsync()
        {
            var query = _configuration.GetSection("Exportaciones:GetConfProductos").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();
                    var productos = await connection.QueryAsync<ConfProducto>(query, commandType: CommandType.Text);
                    connection.Close();
                    return productos;
                }
                catch (Exception e)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        [HttpPost("InsertConfProductosAsync")]
        public async Task InsertConfProductosAsync([FromBody] List<ConfProducto> confProducts)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return;
                try
                {
                    connection.Open();
                    foreach (ConfProducto producto in confProducts)
                    {
                        var query = _configuration.GetSection("Exportaciones:InsertConfProductos").Value.ToString();
                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@codigoProducto", producto.CodigoProducto);
                            command.Parameters.AddWithValue("@nomProducto", producto.NomProducto);
                            command.Parameters.AddWithValue("@codigoKosher", producto.CodigoKosher);
                            command.Parameters.AddWithValue("@clasificacionKosher", producto.ClasificacionKosher);
                            command.Parameters.AddWithValue("@markKosher", producto.MarkKosher);
                            command.Parameters.AddWithValue("@especie", producto.Especie);
                            command.Parameters.AddWithValue("@tipoProducto", producto.TipoProducto);
                            await command.ExecuteNonQueryAsync();
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    if (connection != null) connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpPut("UpdateConfProductosAsync")]
        public async Task UpdateConfProductosAsync([FromBody] List<ConfProducto> confProductos)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return;

                try
                {
                    connection.Open();

                    foreach (ConfProducto producto in confProductos)
                    {
                        var query = _configuration.GetSection("Exportaciones:UpdateConfProductos").Value.ToString();
                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@codigoProducto", producto.CodigoProducto);
                            command.Parameters.AddWithValue("@codigoKosher", producto.CodigoKosher);
                            command.Parameters.AddWithValue("@clasificacionKosher", producto.ClasificacionKosher);
                            command.Parameters.AddWithValue("@markKosher", producto.MarkKosher);
                            command.Parameters.AddWithValue("@especie", producto.Especie);
                            command.Parameters.AddWithValue("@tipoProducto", producto.TipoProducto);
                            await command.ExecuteNonQueryAsync();
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpDelete("DeleteConfProductosAsync")]
        public async Task DeletePedidoAsync(string codigoProducto)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return;

                try
                {
                    connection.Open();
                    var query = _configuration.GetSection("Exportaciones:DeleteConfProductos").Value.ToString();


                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codigoProducto", codigoProducto);
                        await command.ExecuteNonQueryAsync();
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("GetNombreProductoAsync")]
        public async Task<IEnumerable<string?>> GetNombreProductoAsync(string codigo)
        {
            var query = _configuration.GetSection("Exportaciones:GetNombreProducto").Value.ToString().Replace("@codigo", codigo);

            using (var connection = new SqlConnection(_innovaConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();

                    var nombreProducto = await connection.QueryAsync<string?>(query, commandType: CommandType.Text);

                    connection.Close();
                    return nombreProducto;
                }
                catch (Exception e)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetPrimeraFechaPreciosAsync")]
        public async Task<string> GetPrimeraFechaPreciosAsync(string fecha)
        {
            var query = _configuration.GetSection("Exportaciones:GetPrimeraFechaPrecios").Value;
            if (string.IsNullOrEmpty(query)) return "";

            query = query.Replace("@fecha_dada", fecha);
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return "";
                try
                {
                    await connection.OpenAsync();
                    var fechaAnterior = await connection.QueryAsync<DateTime?>(query, commandType: CommandType.Text);

                    return fechaAnterior.FirstOrDefault()?.ToString("yyyy-MM-dd") ?? "";
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("GetIdMonedaParaFechaAsync")]
        public async Task<int> GetIdMonedaParaFechaAsync(string fecha)
        {
            var query = _configuration.GetSection("Exportaciones:GetIdMonedaParaFecha").Value.ToString();
            
            if (string.IsNullOrEmpty(query)) return 0;

            query = query.Replace("@fecha", fecha);
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return 0;
                try
                {
                    await connection.OpenAsync();
                    var idMoneda = await connection.QueryAsync<int>(query, commandType: CommandType.Text);
                    return idMoneda.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    if (connection != null) connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("GetCodigoNombreProductoAsync")]
        public async Task<IEnumerable<ProductoDTO?>> GetNombreProductoAsync()
        {
            var query = _configuration.GetSection("Exportaciones:GetCodigoNombreProducto").Value.ToString();

            using (var connection = new SqlConnection(_innovaConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();

                    var productos = await connection.QueryAsync<ProductoDTO?>(query, commandType: CommandType.Text);

                    connection.Close();
                    return productos;
                }
                catch (Exception e)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetCargaReportesAsync")]
        public async Task<IEnumerable<CargaReporteDTO>> GetCargaReportesAsync(DateTime fechaInicio, DateTime fechaFinal)
        {
            var query = _configuration.GetSection("Exportaciones:GetCargaReportes").Value.ToString();
            
            using(var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();

                    var reportes = await connection.QueryAsync<CargaReporteDTO>(
                        query,
                        new { fechaInicio, fechaFinal },
                        commandType: CommandType.Text
                    );
                    connection.Close();
                    return reportes;
                }
                catch (Exception e)
                {
                    if (connection != null) connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetDetallesCargaReporteAsync")]
        public async Task<IEnumerable<DetalleCargaReporteDTO>> GetDetallesCargaReporteAsync(int id)
        {
            var query = _configuration.GetSection("Exportaciones:GetDetallesCargaReportes").Value.ToString();
            query = query.Replace("@id", id.ToString());
            
            using(var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return null;
                try
                {
                    connection.Open();
                    var detalles = await connection.QueryAsync<DetalleCargaReporteDTO>(query, commandType:CommandType.Text);
                    connection.Close();
                    return detalles;
                }   
                catch (Exception e)
                {
                    if (connection != null) connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        [HttpGet("GetNombresCargaReportesAsync")]
        public async Task<IEnumerable<string>> GetNombresCargaReportes()
        {
            var query = _configuration.GetSection("Exportaciones:GetNombresCargaReportes").Value.ToString();
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return new List<string>();
                try
                {
                    connection.Open();
                    var nombres = await connection.QueryAsync<string>(query, commandType:CommandType.Text);
                    connection.Close();
                    return nombres;
                }
                catch (Exception e)
                {
                    if (connection != null) connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        [HttpPost("InsertCargaReporteAsync")]
        public async Task<ActionResult<decimal>> InsertCargaReporteAsync([FromBody] CargaReporteDTO reporte)
        {
            var query = _configuration.GetSection("Exportaciones:InsertCargaReporte").Value.ToString();
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return -1;
                try
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombreReporte", reporte.NombreReporte);
                        command.Parameters.AddWithValue("@fechaInicio", reporte.FechaInicio);
                        command.Parameters.AddWithValue("@fechaFinal", reporte.FechaFinal);
                        var idGenerado = (decimal)await command.ExecuteScalarAsync();
                        connection.Close();
                        Console.WriteLine(idGenerado);
                        return int.Parse(idGenerado.ToString());
                    }
                }
                catch (Exception e)
                {
                    if (connection != null) connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

        [HttpPost("InsertDetallesReporteCargaAsync")]
        public async Task InsertDetallesReporteCargaAsync([FromBody] List<DetalleCargaReporteDTO> detalles)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return;
                try
                {
                    connection.Open();
                    foreach (DetalleCargaReporteDTO detalle in detalles)
                    {
                        var query = _configuration.GetSection("Exportaciones:InsertDetalleCargaReporte").Value.ToString();
                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@idReporte", detalle.IdReporte);
                            command.Parameters.AddWithValue("@idCarga", detalle.IdCarga);
                            command.Parameters.AddWithValue("@contenedor", detalle.Contenedor);
                            command.Parameters.AddWithValue("@pesoBruto", detalle.PesoBruto);
                            await command.ExecuteNonQueryAsync();
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    if (connection != null) connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpDelete("DeletePrecioIndividualAsync")]
        public async Task DeletePrecioIndividualAsync([FromQuery] string codigoProducto)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return;

                try
                {
                    connection.Open();
                    var query = _configuration.GetSection("Exportaciones:DeletePrecioIndividual").Value.ToString();


                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codigoProducto", codigoProducto);
                        await command.ExecuteNonQueryAsync();
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }
        #endregion

        #endregion
    }
}
