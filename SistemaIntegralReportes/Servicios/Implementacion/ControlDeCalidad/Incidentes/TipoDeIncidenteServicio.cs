using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.ControlDeCalidad.Incidentes;
using SistemaIntegralReportes.Servicios.Contrato.ControlDeCalidad.Incidentes;

namespace SistemaIntegralReportes.Servicios.Implementacion.ControlDeCalidad.Incidentes
{
    public class TipoDeIncidenteServicio : ITipoDeIncidente
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public TipoDeIncidenteServicio(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlTestConection");
        }

        public async Task<List<TipoDeIncidenteDTO>> ListaDeTipoDeIncidente()
        {
            List<TipoDeIncidenteDTO> listaDeTipoDeIncidente = new List<TipoDeIncidenteDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlListaDeTipoDeIncidente = _configuration.GetSection("ControlCalidad:ConsultarTipoDeIncidente").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlListaDeTipoDeIncidente, connection))
                    {

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                listaDeTipoDeIncidente.Add(new TipoDeIncidenteDTO
                                {
                                    IdTipoDeIncidente = reader.GetInt32(reader.GetOrdinal("idTipoDeIncidente")),
                                    Descripcion = reader.GetString(reader.GetOrdinal("descripcion")),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar la trazabilidad", ex);
            }

            return listaDeTipoDeIncidente; 
        }
    }
}
