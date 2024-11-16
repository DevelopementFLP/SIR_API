using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.ControlDeCalidad.Incidentes;
using SistemaIntegralReportes.Servicios.Contrato.ControlDeCalidad.Incidentes;

namespace SistemaIntegralReportes.Servicios.Implementacion.ControlDeCalidad.Incidentes
{
    public class TrazabilidadServicio : ITrazabilidad
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public TrazabilidadServicio(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("InnovaProduccion");
        }



        public async Task<List<TrazabilidadDTO>> BuscarTrazabilidad(int codigoQr)
        {
            List<TrazabilidadDTO> trazabilidadList = new List<TrazabilidadDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlBuscar = _configuration.GetSection("ControlCalidad:ConsultarTrazabilidadDeCorte").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlBuscar, connection))
                    {

                        command.Parameters.AddWithValue("@codigoQr", codigoQr);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                trazabilidadList.Add(new TrazabilidadDTO
                                {
                                    Secuencia = reader.GetInt32(reader.GetOrdinal("Secuencia")),
                                    Puesto = reader["Puesto"].ToString(),
                                    IdElemento = reader["idElemento"].ToString(),
                                    Empleado = reader["Empleado"].ToString(),
                                    Producto = reader["Producto"].ToString(),
                                    Etiqueta = reader["Etiqueta"].ToString(),
                                    Peso = reader["PesoKG"].ToString(),
                                    Hora = reader["Hora"].ToString()
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

            return trazabilidadList; // Devuelve la lista de trazabilidad
        }
    }
}
