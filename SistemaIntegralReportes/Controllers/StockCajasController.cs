using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.Models.StockCajas;
using System.Data;

namespace SistemaIntegralReportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockCajasController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _sirConnectionString;

        public StockCajasController(IConfiguration configuration)
        {
            _configuration = configuration;
            _sirConnectionString = configuration.GetConnectionString("SqlTestConection");
        }

        #region Métodos síncronos
        #endregion

        #region Métodos asíncronos
        [HttpGet("GetTiposCajasAsync")]
        public async Task<IEnumerable<Tipo>> GetTiposCajasAsync()
        {
            var query = _configuration.GetSection("StockCajas:GetTiposCajas").Value.ToString();

            using(var connection = new SqlConnection(_sirConnectionString))
            {
                if(connection == null) return Enumerable.Empty<Tipo>();

                try
                {
                    connection.Open();

                    var tiposCajas = await connection.QueryAsync<Tipo>(query, commandType: CommandType.Text);

                    connection.Close();

                    return tiposCajas;
                }
                catch (Exception ex)
                {
                    if(connection != null)
                        connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("GetTamanoCajasAsync")]
        public async Task<IEnumerable<Tamano>> GetTamanoCajasAsync()
        {
            var query = _configuration.GetSection("StockCajas:GetTamanos").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return Enumerable.Empty<Tamano>();

                try
                {
                    connection.Open();

                    var tamanoCajas = await connection.QueryAsync<Tamano>(query, commandType: CommandType.Text);

                    connection.Close();

                    return tamanoCajas;
                }
                catch (Exception ex)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("GetStockCajasAsync")]
        public async Task<IEnumerable<StockCaja>> GetStockCajasAsync()
        {
            var query = _configuration.GetSection("StockCajas:GetStock").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return Enumerable.Empty<StockCaja>();

                try
                {
                    connection.Open();

                    var stock = await connection.QueryAsync<StockCaja>(query, commandType: CommandType.Text);

                    connection.Close();

                    return stock;
                }
                catch (Exception ex)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("GetPedidosAsync")]
        public async Task<IEnumerable<Pedido>> GetPedidosAsync()
        {
            var query = _configuration.GetSection("StockCajas:GetPedidos").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return Enumerable.Empty<Pedido>();

                try
                {
                    connection.Open();

                    var pedidos = await connection.QueryAsync<Pedido>(query, commandType: CommandType.Text);

                    connection.Close();

                    return pedidos;
                }
                catch (Exception ex)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("GetPedidosPadreAsync")]
        public async Task<IEnumerable<PedidoPadre>> GetPedidosPadreAsync()
        {
            var query = _configuration.GetSection("StockCajas:GetPedidosPadre").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return Enumerable.Empty<PedidoPadre>();

                try
                {
                    connection.Open();

                    var pedidos = await connection.QueryAsync<PedidoPadre>(query, commandType: CommandType.Text);

                    connection.Close();

                    return pedidos;
                }
                catch (Exception ex)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("GetOrdenesEntregaAsync")]
        public async Task<IEnumerable<OrdenEntrega>> GetOrdenesEntregaAsync(int estado)
        {
            var query = _configuration.GetSection("StockCajas:GetOrdenesEntrega").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return Enumerable.Empty<OrdenEntrega>();

                try
                {
                    connection.Open();
                    query = query.Replace("@estado", estado.ToString());

                    var ordenEntrega = await connection.QueryAsync<OrdenEntrega>(query, commandType: CommandType.Text);

                    connection.Close();

                    return ordenEntrega;
                }
                catch (Exception ex)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("GetOrdenesArmadoAsync")]
        public async Task<IEnumerable<OrdenArmado>> GetOrdenesArmadoAsync(int estado)
        {
            var query = _configuration.GetSection("StockCajas:GetOrdenesArmado").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return Enumerable.Empty<OrdenArmado>();

                try
                {
                    connection.Open();
                    query = query.Replace("@estado", estado.ToString());
                    var ordenArmado = await connection.QueryAsync<OrdenArmado>(query, commandType: CommandType.Text);
                    
                    connection.Close();

                    return ordenArmado;
                }
                catch (Exception ex)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("GetDisenosAsync")]
        public async Task<IEnumerable<Diseno>> GetDisenosAsync()
        {
            var query = _configuration.GetSection("StockCajas:GetDisenos").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return Enumerable.Empty<Diseno>();

                try
                {
                    connection.Open();

                    var disenos = await connection.QueryAsync<Diseno>(query, commandType: CommandType.Text);

                    connection.Close();

                    return disenos;
                }
                catch (Exception ex)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpGet("GetCajasAsync")]
        public async Task<IEnumerable<Caja>> GetCajasAsync()
        {
            var query = _configuration.GetSection("StockCajas:GetCajas").Value.ToString();

            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return Enumerable.Empty<Caja>();

                try
                {
                    connection.Open();

                    var cajas = await connection.QueryAsync<Caja>(query, commandType: CommandType.Text);

                    connection.Close();

                    return cajas;
                }
                catch (Exception ex)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpPost("InsertPedidoAsync")]
        public async Task<int> InsertPedidoAsync([FromBody] List<Pedido> pedidos)
        {
            using(var connection = new SqlConnection(_sirConnectionString))
            { 

                if(connection == null) return 0;

                var lastId = 0;

                try
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        foreach (Pedido pedido in pedidos)
                        {
                            var query = _configuration.GetSection("StockCajas:InsertPedido").Value.ToString();
                            using (var command = new SqlCommand(query, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@idCaja", pedido.Id_Caja);
                                command.Parameters.AddWithValue("@fecha", pedido.Fecha_Pedido);
                                command.Parameters.AddWithValue("@prioridad", pedido.Prioridad);
                                command.Parameters.AddWithValue("@stockPedido", pedido.Stock_Pedido);
                                command.Parameters.AddWithValue("@paraStock", pedido.Para_Stock);
                                command.Parameters.AddWithValue("@estado", pedido.Estado);
                                command.Parameters.AddWithValue("@idPedidoPadre", pedido.Id_Pedido_Padre);

                                lastId = Convert.ToInt32(await command.ExecuteScalarAsync());
                            }
                        }

                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    if(connection != null)
                        connection.Close();
                    throw new Exception(ex.Message);
                }

                return lastId;
            }
        }

        [HttpPost("InsertPedidoPadreAsync")]
        public async Task<int> InsertPedidoPadreAsync([FromBody] List<PedidoPadre> pedidos)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {

                if (connection == null) return 0;

                var lastId = 0;

                try
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        foreach (PedidoPadre pedido in pedidos)
                        {
                            var query = _configuration.GetSection("StockCajas:InsertPedidoPadre").Value.ToString();
                            using (var command = new SqlCommand(query, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@prioridad", pedido.Prioridad_Pedido_Padre);
                                lastId = Convert.ToInt32(await command.ExecuteScalarAsync());
                            }
                        }

                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    if (connection != null)
                        connection.Close();
                    throw new Exception(ex.Message);
                }

                return lastId;
            }
        }

        [HttpPost("InsertOrdenArmadoAsync")]
        public async Task InsertOrdenArmadoAsync([FromBody] List<OrdenArmado> ordenes)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return;

                try
                {
                    connection.Open();

                    foreach (OrdenArmado orden in ordenes)
                    {
                        var query = _configuration.GetSection("StockCajas:InsertOrdenArmado").Value.ToString();
                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@idPedido", orden.Id_Pedido);
                            command.Parameters.AddWithValue("@cajasArmar", orden.Cajas_A_Armar);
                            command.Parameters.AddWithValue("@cajasArmada", orden.Cajas_Armadas);
                            command.Parameters.AddWithValue("@idDestino", orden.Id_Destino);
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

        [HttpPost("InsertOrdenEntregaAsync")]
        public async Task InsertOrdenEntregaAsync([FromBody] List<OrdenEntrega> ordenes)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return;

                try
                {
                    connection.Open();

                    foreach (OrdenEntrega orden in ordenes)
                    {
                        var query = _configuration.GetSection("StockCajas:InsertOrdenEntrega").Value.ToString();
                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@idPedido", orden.Id_Pedido);
                            command.Parameters.AddWithValue("@cajasEntregar", orden.Cajas_A_Entregar);
                            command.Parameters.AddWithValue("@cajasEntregadas", orden.Cajas_Entregadas);
 
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

        [HttpPut("UpdateOrdenArmadoCajasArmadasAsync")]
        public async Task UpdateOrdenArmadoCajasArmadasAsync([FromBody] List<OrdenArmado> ordenes)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return;

                try
                {
                    connection.Open();

                    foreach (OrdenArmado orden in ordenes)
                    {
                        var query = _configuration.GetSection("StockCajas:UpdateOrdenArmadoCajasArmadas").Value.ToString();
                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@idPedido", orden.Id_Pedido);           
                            command.Parameters.AddWithValue("@cajasArmadas", orden.Cajas_Armadas);
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

        [HttpPut("UpdateOrdenArmadoAsync")]
        public async Task UpdateOrdenArmadoAsync([FromBody] List<OrdenArmado> ordenes)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return;

                try
                {
                    connection.Open();

                    foreach (OrdenArmado orden in ordenes)
                    {
                        var query = _configuration.GetSection("StockCajas:UpdateOrdenArmado").Value.ToString();
                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@idPedido", orden.Id_Pedido);
                            command.Parameters.AddWithValue("@cajasArmar", orden.Cajas_A_Armar);
                            command.Parameters.AddWithValue("@cajasArmadas", orden.Cajas_Armadas);
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

        [HttpPut("UpdateOrdenEntregaCajasEntregadasAsync")]
        public async Task UpdateOrdenEntregaCajasEntregadasAsync([FromBody] List<OrdenEntrega> ordenes)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return;

                try
                {
                    connection.Open();

                    foreach (OrdenEntrega orden in ordenes)
                    {
                        var query = _configuration.GetSection("StockCajas:UpdateOrdenEntregaCajasEntregadas").Value.ToString();
                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@idPedido", orden.Id_Pedido);
                            command.Parameters.AddWithValue("@cajasEntregadas", orden.Cajas_Entregadas);
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

        [HttpPut("UpdateOrdenEntregaAsync")]
        public async Task UpdateOrdenEntregaAsync([FromBody] List<OrdenEntrega> ordenes)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return;

                try
                {
                    connection.Open();

                    foreach (OrdenEntrega orden in ordenes)
                    {
                        var query = _configuration.GetSection("StockCajas:UpdateOrdenEntrega").Value.ToString();
                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@idPedido", orden.Id_Pedido);
                            command.Parameters.AddWithValue("@cajasEntregar", orden.Cajas_A_Entregar);
                            command.Parameters.AddWithValue("@cajasEntregadas", orden.Cajas_Entregadas);
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



        [HttpPut("UpdateStockAsync")]
        public async Task UpdateStockAsync([FromBody] List<StockCaja> ordenes)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return;

                try
                {
                    connection.Open();

                    foreach (StockCaja orden in ordenes)
                    {
                        var query = _configuration.GetSection("StockCajas:UpdateStock").Value.ToString();
                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@idCaja", orden.Id_Caja);
                            command.Parameters.AddWithValue("@stock", orden.Stock);
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

        [HttpPut("UpdatePedidoPadreAsync")]
        public async Task UpdatePedidoPadreAsync([FromBody] List<PedidoPadre> pedidos)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return;

                try
                {
                    connection.Open();

                    foreach (PedidoPadre pedido in pedidos)
                    {
                        var query = _configuration.GetSection("StockCajas:UpdatePedidoPadre").Value.ToString();
                        using (var command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@prioridad", pedido.Prioridad_Pedido_Padre);
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

        [HttpDelete("DeletePedidoAsync")]
        public async Task DeletePedidoAsync(int idPedido)
        {
            using (var connection = new SqlConnection(_sirConnectionString))
            {
                if (connection == null) return;

                try
                {
                    connection.Open();
                    var query = _configuration.GetSection("StockCajas:DeletePedido").Value.ToString();

            
                   using (var command = new SqlCommand(query, connection))
                   {
                        command.Parameters.AddWithValue("@idPedido", idPedido);
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

    }
}
