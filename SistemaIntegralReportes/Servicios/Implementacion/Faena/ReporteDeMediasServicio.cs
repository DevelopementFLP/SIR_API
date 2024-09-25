using AutoMapper;
using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.Abasto;
using SistemaIntegralReportes.Models.Dispositivos;
using SistemaIntegralReportes.Models.Faena.Reportes;
using SistemaIntegralReportes.Servicios.Contrato.Faena;
using System.Data;

namespace SistemaIntegralReportes.Servicios.Implementacion.Faena
{
    public class ReporteDeMediasServicio : IReporteDeFaena
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;


        public ReporteDeMediasServicio(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("InnovaProduccion");
        }        

        public async Task<List<ReporteDeMediasProductoDTO>> GetReportePorProducto(string fechaDesde, string fechaHasta, string horaDesde, string horaHasta)
        {
            List<ReporteDeMediasProductoDTO> _listaDeResultadoProducto = new List<ReporteDeMediasProductoDTO>();

            fechaDesde = fechaDesde + " " + horaDesde +":00:00.000";
            fechaHasta = fechaHasta + " " + horaHasta + ":59:58.000";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlBusquedaDeQr = _configuration.GetSection("SeccionAbasto:ReporteDeMediasProducto").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlBusquedaDeQr, connection))
                    {
                        

                        // Agregamos el parámetro con los comodines '%' incluidos
                        command.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                        command.Parameters.AddWithValue("@fechaHasta", fechaHasta);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string producto = reader.GetString(reader.GetOrdinal("Producto"));
                                string grade = reader.GetString(reader.GetOrdinal("Grade"));
                                int cuartos = reader.GetInt32(reader.GetOrdinal("Cuartos"));
                                double pesoCuartos = reader.GetDouble(reader.GetOrdinal("PesoCuartos"));


                                ReporteDeMediasProductoDTO lista = new ReporteDeMediasProductoDTO
                                {
                                    Producto = producto,
                                    Grade = grade,
                                    Cuartos = cuartos,
                                    PesoCuartos = pesoCuartos
                                };

                                _listaDeResultadoProducto.Add(lista);
                            }
                        }
                    }
                    connection.Close();
                }
                return _listaDeResultadoProducto.OrderBy(item => item.Grade).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ReporteDeMediasProveedorDTO>> GetReportePorProveedor(string fechaDesde, string fechaHasta, string horaDesde, string horaHasta)
        {
            List<ReporteDeMediasProveedorDTO> _listaDeResultadoProveedor = new List<ReporteDeMediasProveedorDTO>();

            fechaDesde = fechaDesde + " " + horaDesde +":00:00.000";
            fechaHasta = fechaHasta + " " + horaHasta + ":59:58.000";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string sqlBusquedaDeQr = _configuration.GetSection("SeccionAbasto:ReporteDeMediasProveedor").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlBusquedaDeQr, connection))
                    {
                        // Agregamos el parámetro con los comodines '%' incluidos
                        command.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                        command.Parameters.AddWithValue("@fechaHasta", fechaHasta);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string proveedor = reader.GetString(reader.GetOrdinal("Proveedor"));
                                string tropa = reader.GetString(reader.GetOrdinal("Tropa"));
                                string grade = reader.GetString(reader.GetOrdinal("Grade"));
                                Int32 medias = reader.GetInt32(reader.GetOrdinal("Medias"));
                                double pesoMedias = reader.GetDouble(reader.GetOrdinal("PesoMedias"));


                                ReporteDeMediasProveedorDTO lista = new ReporteDeMediasProveedorDTO
                                {
                                    Proveedor = proveedor,
                                    Tropa = tropa,
                                    Grade = grade,
                                    Medias = medias,
                                    PesoMedias = pesoMedias
                                };

                                _listaDeResultadoProveedor.Add(lista);
                            }
                        }
                    }
                    connection.Close();
                }
                return _listaDeResultadoProveedor.OrderBy(item => item.Proveedor).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
    }
}
