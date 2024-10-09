using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.FichaTecnica;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;
using Microsoft.Extensions.Configuration;

namespace SistemaIntegralReportes.Servicios.Implementacion.FichaTecnica
{
    public class FtPhService : IFtPh
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public FtPhService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlTestConection");
        }

        public async Task<List<PhDTO>> Lista()
        {
            List<PhDTO> listaPh = new List<PhDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlListar = _configuration.GetSection("FichaTecnica:FtListarPh").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlListar, connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                listaPh.Add(new PhDTO
                                {
                                    IdPh = reader.GetInt32(reader.GetOrdinal("IdPh")),
                                    Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                    Valor = reader.GetDecimal(reader.GetOrdinal("Valor")),
                                });
                            }
                        }
                    }
                }

                return listaPh;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de pH", ex);
            }
        }

        public async Task<PhDTO> Crear(PhDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlCrear = _configuration.GetSection("FichaTecnica:FtCrearPh").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlCrear, connection))
                    {
                        command.Parameters.AddWithValue("@Valor", modelo.Valor);
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);

                        var respuestaDelModelo = await command.ExecuteReaderAsync();

                        if (await respuestaDelModelo.ReadAsync())
                        {
                            return new PhDTO
                            {
                                IdPh = respuestaDelModelo.GetInt32(respuestaDelModelo.GetOrdinal("IdPh")),
                                Nombre = respuestaDelModelo.GetString(respuestaDelModelo.GetOrdinal("nombre")),
                                Valor = respuestaDelModelo.GetDecimal(respuestaDelModelo.GetOrdinal("Valor")),                                
                            };
                        }
                        else
                        {
                            throw new TaskCanceledException("No se pudo crear el pH");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el pH", ex);
            }
        }

        public async Task<bool> Editar(PhDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEditar = _configuration.GetSection("FichaTecnica:FtEditarPh").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEditar, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@Valor", modelo.Valor);
                        command.Parameters.AddWithValue("@IdPh", modelo.IdPh);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el pH", ex);
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEliminar = _configuration.GetSection("FichaTecnica:FtEliminarPh").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEliminar, connection))
                    {
                        command.Parameters.AddWithValue("@idPh", id);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el pH", ex);
            }
        }
    }
}
