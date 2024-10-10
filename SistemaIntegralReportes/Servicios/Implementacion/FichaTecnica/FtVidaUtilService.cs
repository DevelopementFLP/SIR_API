using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.FichaTecnica;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;
using Microsoft.Extensions.Configuration;

namespace SistemaIntegralReportes.Servicios.Implementacion.FichaTecnica
{
    public class FtVidaUtilService : IFtVidaUtil
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public FtVidaUtilService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlTestConection");
        }

        public async Task<List<VidaUtilDTO>> Lista()
        {
            List<VidaUtilDTO> listaVidaUtil = new List<VidaUtilDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlListar = _configuration.GetSection("FichaTecnica:FtListarVidaUtil").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlListar, connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                listaVidaUtil.Add(new VidaUtilDTO
                                {
                                    IdVidaUtil = reader.GetInt32(reader.GetOrdinal("IdVidaUtil")),
                                    Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                    Duracion = reader.GetString(reader.GetOrdinal("duracion"))
                                });
                            }
                        }
                    }
                }

                return listaVidaUtil;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Vida Útil", ex);
            }
        }

        public async Task<VidaUtilDTO> Crear(VidaUtilDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlCrear = _configuration.GetSection("FichaTecnica:FtCrearVidaUtil").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlCrear, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@Duracion", modelo.Duracion);

                        var respuestaDelModelo = await command.ExecuteReaderAsync();

                        if (await respuestaDelModelo.ReadAsync())
                        {
                            return new VidaUtilDTO
                            {
                                IdVidaUtil = respuestaDelModelo.GetInt32(respuestaDelModelo.GetOrdinal("IdVidaUtil")),
                                Nombre = respuestaDelModelo.GetString(respuestaDelModelo.GetOrdinal("nombre")),
                                Duracion = respuestaDelModelo.GetString(respuestaDelModelo.GetOrdinal("duracion"))
                            };
                        }
                        else
                        {
                            throw new TaskCanceledException("No se pudo crear la Vida Útil");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la Vida Útil", ex);
            }
        }

        public async Task<bool> Editar(VidaUtilDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEditar = _configuration.GetSection("FichaTecnica:FtEditarVidaUtil").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEditar, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@Duracion", modelo.Duracion);
                        command.Parameters.AddWithValue("@IdVidaUtil", modelo.IdVidaUtil);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar la Vida Útil", ex);
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEliminar = _configuration.GetSection("FichaTecnica:FtEliminarVidaUtil").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEliminar, connection))
                    {
                        command.Parameters.AddWithValue("@idVidaUtil", id);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la Vida Útil", ex);
            }
        }
    }
}
