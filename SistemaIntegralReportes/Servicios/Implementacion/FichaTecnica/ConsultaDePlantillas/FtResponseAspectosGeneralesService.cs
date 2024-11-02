using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.FichaTecnica.Plantillas;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica.ConsultaDePlantillas;

namespace SistemaIntegralReportes.Servicios.Implementacion.FichaTecnica.ConsultaDePlantillas
{
    public class FtResponseAspectosGeneralesService : IFtResponseAspectosGeneralesPlantilla
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public FtResponseAspectosGeneralesService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlTestConection");
            _configuration = configuration;
        }

        public async Task<List<ResponseAspectosGeneralesDTO>> ObtenerAspectosGeneralesPlantilla(int idPlantilla)
        {
            var aspectosGenerales = new List<ResponseAspectosGeneralesDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlCrear = _configuration.GetValue<string>("FichaTecnica:FtBuscarPlantillaAspectosGenerales");

                    using (SqlCommand command = new SqlCommand(sqlCrear, connection))
                    {
                        // Agregar el parámetro
                        command.Parameters.AddWithValue("@idPlantilla", idPlantilla);

                        // Ejecutar el comando y obtener los resultados
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var aspecto = new ResponseAspectosGeneralesDTO
                                {
                                    NombreDePlantilla = reader.GetString(reader.GetOrdinal("NombreDePlantilla")),
                                    Marca = reader.GetString(reader.GetOrdinal("Marca")),
                                    TipoDeUso = reader.GetString(reader.GetOrdinal("TipoDeUso")),
                                    Alergeno = reader.GetString(reader.GetOrdinal("Alergeno")),
                                    Almacenamiento = reader.GetString(reader.GetOrdinal("Almacenamiento")),
                                    VidaUtil = reader.GetString(reader.GetOrdinal("VidaUtil")),
                                    TipoDeEnvase = reader.GetString(reader.GetOrdinal("TipoDeEnvase")),
                                    PresentacionDeEnvase = reader.GetString(reader.GetOrdinal("PresentacionDeEnvase")),
                                    PesoPromedio = reader.GetDecimal(reader.GetOrdinal("pesoPromedio")),
                                    UnidadesPorCaja = reader.GetInt32(reader.GetOrdinal("unidadesPorCaja")),
                                    Dimensiones = reader.GetString(reader.GetOrdinal("dimensiones"))
                                };

                                aspectosGenerales.Add(aspecto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los Aspectos Generales de la Plantilla", ex);
            }

            return aspectosGenerales;
        }
    }
}
