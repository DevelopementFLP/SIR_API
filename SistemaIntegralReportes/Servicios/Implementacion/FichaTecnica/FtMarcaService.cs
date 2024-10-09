using AutoMapper;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.FichaTecnica;
using SistemaIntegralReportes.Models.Dispositivos;
using SistemaIntegralReportes.Repositorio.Contrato;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Implementacion.FichaTecnica
{
    public class FtMarcaService : IFtMarcas
    {

        private readonly string _connectionString;
        private readonly IConfiguration _configuration;


        public FtMarcaService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlTestConection");
        }

        public async Task<List<MarcaDTO>> Lista()
        {
            List<MarcaDTO> listaMarcas = new List<MarcaDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEditar = _configuration.GetSection("FichaTecnica:FtListarMarcas").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEditar, connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                listaMarcas.Add(new MarcaDTO
                                {
                                    IdMarca = reader.GetInt32(reader.GetOrdinal("IdMarca")),
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
                throw new Exception("Error al obtener la lista de marcas", ex);
            }
        }

        public async Task<MarcaDTO> Crear(MarcaDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlCrear = _configuration.GetSection("FichaTecnica:FtCrearMArca").Value.ToString();                    

                    using (SqlCommand command = new SqlCommand(sqlCrear, connection))
                    {
                        // Agregar parámetros
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@Descripcion", modelo.Descripcion);

                        // Ejecutar el comando y obtener los resultados
                        var respuestaDelModelo = await command.ExecuteReaderAsync();

                        if (await respuestaDelModelo.ReadAsync())
                        {
                            return new MarcaDTO
                            {
                                IdMarca = respuestaDelModelo.GetInt32(respuestaDelModelo.GetOrdinal("idMarca")),
                                Nombre = respuestaDelModelo.GetString(respuestaDelModelo.GetOrdinal("Nombre")),
                                Descripcion = respuestaDelModelo.GetString(respuestaDelModelo.GetOrdinal("Descripcion"))
                            };
                        }
                        else
                        {
                            throw new TaskCanceledException("No se pudo crear la marca");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la marca", ex);
            }
        }

        public async Task<bool> Editar(MarcaDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEditar = _configuration.GetSection("FichaTecnica:FtEditarMarca").Value.ToString();                    

                    using (SqlCommand command = new SqlCommand(sqlEditar, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
                        command.Parameters.AddWithValue("@Descripcion", modelo.Descripcion);
                        command.Parameters.AddWithValue("@IdMarca", modelo.IdMarca);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();
                        return filasAfectadas > 0; // Retorna true si se actualizó al menos una fila
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar la marca", ex);
            }
        }


        public async Task<bool> Eliminar(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlEditar = _configuration.GetSection("FichaTecnica:FtEliminarMarca").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlEditar, connection))
                    {
                        command.Parameters.AddWithValue("@IdMarca", id);

                        int filasAfectadas = await command.ExecuteNonQueryAsync();
                        return filasAfectadas > 0; // Retorna true si se eliminó al menos una fila
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
