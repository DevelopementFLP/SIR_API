using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.FichaTecnica;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Implementacion.FichaTecnica
{
    public class FtProductosService : IFtProductos
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public FtProductosService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlTestConection");
        }

        public async Task<ProductoFichaTecnicaDTO> BuscarProducto(string codigoProducto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlBuscar = _configuration.GetSection("FichaTecnica:FtBuscarProducto").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlBuscar, connection))
                    {
                        command.Parameters.AddWithValue("@codigoProducto", codigoProducto);

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new ProductoFichaTecnicaDTO
                                {
                                    IdProducto = reader.GetInt32(reader.GetOrdinal("idProducto")),
                                    CodigoProducto = reader.GetString(reader.GetOrdinal("codigoProducto")),
                                    Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                    NombreDeProductoParaFicha = reader.GetString(reader.GetOrdinal("descripcion_producto_en_ficha")),                                    
                                    Calibre = reader.GetString(reader.GetOrdinal("calibre")),
                                };
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el Producto", ex);
            }
        }

        public async Task<ProductoFichaTecnicaDTO> CrearProducto(ProductoFichaTecnicaDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlCrear = _configuration.GetSection("FichaTecnica:FtCrearProducto").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlCrear, connection))
                    {
                        command.Parameters.AddWithValue("@codigoDeProducto", modelo.CodigoProducto);
                        command.Parameters.AddWithValue("@nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@descripcionProductoEnFicha", modelo.NombreDeProductoParaFicha);
                        command.Parameters.AddWithValue("@calibre", modelo.Calibre);
                        command.Parameters.AddWithValue("@material", "");
                        command.Parameters.AddWithValue("@grupoMadre", "");
                        command.Parameters.AddWithValue("@Observacion", "");

                        // Ejecutar la consulta de inserción
                        int filasAfectadas = await command.ExecuteNonQueryAsync();

                        if (filasAfectadas > 0)
                        {
                            return modelo;
                        }
                        else
                        {
                            throw new Exception("No se pudo crear el producto.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el Producto", ex);
            }
        }


        public async Task<bool> Editar(ProductoFichaTecnicaDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEditar = _configuration.GetSection("FichaTecnica:FtEditarProducto").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEditar, connection))
                    {
                        command.Parameters.AddWithValue("@CodigoProducto", modelo.CodigoProducto);
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);                                                                    
                        command.Parameters.AddWithValue("@NombreProductoEnFicha", modelo.NombreDeProductoParaFicha);                        
                        command.Parameters.AddWithValue("@Calibre", modelo.Calibre);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();
                        return filasAfectadas > 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el Producto", ex);
            }
        }       
    }
}
