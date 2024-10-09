using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.FichaTecnica;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Implementacion.FichaTecnica
{
    public class FtColorService : IFtColor
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;


        public FtColorService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlTestConection");
        }

        public async Task<List<ColorDTO>> Lista()
        {
            List<ColorDTO> listaMarcas = new List<ColorDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlListar = _configuration.GetSection("FichaTecnica:FtListarColores").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlListar, connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                listaMarcas.Add(new ColorDTO
                                {
                                    IdColor = reader.GetInt32(reader.GetOrdinal("IdColor")),
                                    Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion"))
                                });
                            }
                        }
                    }
                }

                return listaMarcas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Colores", ex);
            }
        }

        public async Task<ColorDTO> Crear(ColorDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlCrear = _configuration.GetSection("FichaTecnica:FtCrearColor").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlCrear, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@Descripcion", modelo.Descripcion);

                        // Ejecutar el comando y obtener los resultados
                        var respuestaDelModelo = await command.ExecuteReaderAsync();

                        if (await respuestaDelModelo.ReadAsync())
                        {
                            return new ColorDTO
                            {
                                IdColor = respuestaDelModelo.GetInt32(respuestaDelModelo.GetOrdinal("idColor")),
                                Nombre = respuestaDelModelo.GetString(respuestaDelModelo.GetOrdinal("Nombre")),
                                Descripcion = respuestaDelModelo.GetString(respuestaDelModelo.GetOrdinal("Descripcion"))
                            };
                        }
                        else
                        {
                            throw new TaskCanceledException("No se pudo crear el Color");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el Color", ex);
            }
        }

        public async Task<bool> Editar(ColorDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEditar = _configuration.GetSection("FichaTecnica:FtEditarColor").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEditar, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@Descripcion", modelo.Descripcion);
                        command.Parameters.AddWithValue("@IdColor", modelo.IdColor);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();
                        return filasAfectadas > 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el Color", ex);
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEditar = _configuration.GetSection("FichaTecnica:FtEliminarColor").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEditar, connection))
                    {
                        command.Parameters.AddWithValue("@idColor", id);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();
                        return filasAfectadas > 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la marca", ex);
            }
        }

    }
}
