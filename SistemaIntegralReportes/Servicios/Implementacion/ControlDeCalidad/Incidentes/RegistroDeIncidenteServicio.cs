using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.ControlDeCalidad.Incidentes;
using SistemaIntegralReportes.Servicios.Contrato.ControlDeCalidad.Incidentes;
using System.Data;

namespace SistemaIntegralReportes.Servicios.Implementacion.ControlDeCalidad.Incidentes
{
    public class RegistroDeIncidenteServicio : IRegistroDeIncidente
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public RegistroDeIncidenteServicio(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlTestConection");
            _configuration = configuration;
        }

        public async Task<RegistroDeIncidenteDTO> Crear(string codigoQr, string PuestoDeTrabajo, string Empleado, string Producto, string Hora, int IdTipoDeIncidente, byte[] imagenBytes)
        {
            var modelo = new RegistroDeIncidenteDTO
            {
                codigoQr = codigoQr,
                PuestoDeTrabajo = PuestoDeTrabajo,
                Empleado = Empleado,
                Producto = Producto,
                Hora = Hora, 
                IdTipoDeIncidente = IdTipoDeIncidente
            };

            // separo el código de empleado y el nombre
            string[] empleadoParts = Empleado.Split('-');
            string codigoDeEmpleado = empleadoParts[0].Trim(); 
            string nombreDeEmpleado = empleadoParts.Length > 1 ? empleadoParts[1].Trim() : "";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string sqlInsertarIncidente = _configuration.GetSection("ControlCalidad:InsertarIncidente").Value.ToString();

                using (SqlCommand command = new SqlCommand(sqlInsertarIncidente, connection))
                {
                    // Agregar los parámetros al comando SQL
                    command.Parameters.AddWithValue("@codigoQr", modelo.codigoQr);
                    command.Parameters.AddWithValue("@PuestoDeTrabajo", modelo.PuestoDeTrabajo);
                    command.Parameters.AddWithValue("@codigoDeEmpleado", codigoDeEmpleado);
                    command.Parameters.AddWithValue("@nombreDeEmpleado", nombreDeEmpleado);
                    command.Parameters.AddWithValue("@Producto", modelo.Producto);
                    command.Parameters.AddWithValue("@Hora", modelo.Hora);
                    command.Parameters.AddWithValue("@IdTipoDeIncidente", modelo.IdTipoDeIncidente);
                    command.Parameters.AddWithValue("@ImagenDeIncidente", imagenBytes);

                    modelo.IdIncidente = (int)await command.ExecuteScalarAsync();
                }
            }

            return modelo;
        }

        public async Task<List<IncidentesDTO>> ListaDeIncidentes(string fechaDelDia)
        {
            var incidentes = new List<IncidentesDTO>();

            string fechaDesde = fechaDelDia + " 00:01:00";
            string fechaHasta = fechaDelDia + " 23:59:59";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string sqlGetIncidentes = _configuration.GetSection("ControlCalidad:ListaDeIncidentes").Value;

                using (SqlCommand command = new SqlCommand(sqlGetIncidentes, connection))
                {

                    // Añadimos los parámetros de fecha desde y hasta
                    command.Parameters.Add(new SqlParameter("@FechaDesde", SqlDbType.DateTime) { Value = DateTime.Parse(fechaDesde) });
                    command.Parameters.Add(new SqlParameter("@FechaHasta", SqlDbType.DateTime) { Value = DateTime.Parse(fechaHasta) });

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var incidente = new IncidentesDTO
                            {
                                IdIncidente = reader.GetInt32(reader.GetOrdinal("idIncidente")),
                                codigoQr = reader.GetString(reader.GetOrdinal("codigoQr")),
                                PuestoDeTrabajo = reader.GetString(reader.GetOrdinal("puestoDeTrabajo")),
                                CodigoDeEmpleado = reader.GetString(reader.GetOrdinal("codigoDeEmpleado")),
                                NombreDeEmpleado = reader.GetString(reader.GetOrdinal("nombreDeEmpleado")),
                                Producto = reader.GetString(reader.GetOrdinal("producto")),
                                Hora = reader.GetString(reader.GetOrdinal("hora")),
                                TipoDeIncidente = reader.GetString(reader.GetOrdinal("descripcion")),
                                ImagenDeIncidente = Convert.ToBase64String((byte[])reader["imagenDeIncidente"]),
                                FechaDeRegistro = reader.GetDateTime(reader.GetOrdinal("fechaDeRegistro")).ToString("yyyy-MM-dd HH:mm:ss"),
                            };

                            incidentes.Add(incidente);
                        }
                    }
                }
            }

            return incidentes;
        }

    }
}
