using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using SistemaIntegralReportes.Models.Dispositivos;
using SistemaIntegralReportes.Models.StockCajas;

using SistemaIntegralReportes.Repositorio.Contrato;
using SistemaIntegralReportes.Servicios.Contrato;
using SistemaIntegralReportes.Models.Reportes;
using System.Runtime.Intrinsics.X86;

namespace SistemaIntegralReportes.Servicios.Implementacion
{
    public class ListaDeCajasServicio : IListaDeCajas
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public ListaDeCajasServicio(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlTestConection");
        }

        public async Task<List<ListaDeCajas>> BuscarListaDeLecturas(string id)
        {
            List<ListaDeCajas> miListaDeCajasFiltrada = new List<ListaDeCajas>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string sqlLecturas = _configuration.GetSection("Dispositivos:ReporteDeLecturas").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlLecturas, connection))
                    {
                        //Agrego el parametro de la consulta
                        command.Parameters.AddWithValue("@cajaBuscada", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime fecha = reader.GetDateTime(0);
                                string dispositovo = reader.GetString(1);
                                string ubicacion = reader.GetString(2);
                                string lectura = reader.GetString(3);
                                Int64 idCaja = reader.GetInt64(4);


                                ListaDeCajas articulo = new ListaDeCajas
                                {
                                    Fecha = fecha.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                                    Dispositivo = dispositovo,
                                    Ubicacion = ubicacion,
                                    Lectura = lectura,
                                    IdCaja = idCaja,
                                };

                                miListaDeCajasFiltrada.Add(articulo);
                            }
                        }
                    }
                    connection.Close();
                }
                return miListaDeCajasFiltrada.OrderBy(a => a.Ubicacion).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }                        
        }

        public async Task<List<ListaDeCajas>> BuscarListaDeExportaciones(string id)
        {
            List<ListaDeCajas> miListaDeExpoFiltrada = new List<ListaDeCajas>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string sqlLecturas = _configuration.GetSection("Dispositivos:ReporteDeLecturasExpo").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlLecturas, connection))
                    {
                        //Agrego el parametro de la consulta
                        command.Parameters.AddWithValue("@palletExpo", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime fecha = reader.GetDateTime(0);
                                string dispositovo = reader.GetString(1);
                                string ubicacion = reader.GetString(2);
                                string lectura = reader.GetString(3);
                                Int32 idCaja = reader.GetInt32(4);


                                ListaDeCajas articulo = new ListaDeCajas
                                {
                                    Fecha = fecha.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                                    Dispositivo = dispositovo,
                                    Ubicacion = ubicacion,
                                    Lectura = lectura,
                                    IdCaja = idCaja,
                                };

                                miListaDeExpoFiltrada.Add(articulo);
                            }
                        }
                    }
                    connection.Close();
                }
                return miListaDeExpoFiltrada.OrderBy(a => a.Ubicacion).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public async Task<List<LecturasConError>> MostrarLecturasConError()
        {
            List<LecturasConError> _listaDeCajasConError = new List<LecturasConError>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string sqlLecturas = _configuration.GetSection("Dispositivos:LecturasConError").Value.ToString();

                    using (SqlCommand command = new SqlCommand(sqlLecturas, connection))
                    {
                        //Agrego el parametro de la consulta
                        //command.Parameters.AddWithValue("@cajaBuscada", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Int32 idCaja = reader.GetInt32(0);
                                string idQr = reader.GetString(1);
                                string codigo = reader.GetString(2);
                                string nombre = reader.GetString(3);
                                float peso = reader.GetFloat(4);
                                float cl = reader.GetFloat(5);
                                DateTime fechaDeProduccion = reader.GetDateTime(6);
                                DateTime fechaDeCreado = reader.GetDateTime(7);
                                DateTime fechaDeCerrado = reader.GetDateTime(8);
                                string registro = reader.GetString(9);
                                string estado = reader.GetString(10);

                                LecturasConError lectura = new LecturasConError
                                {                                    
                                    IdCaja = idCaja,
                                    IdQr = idQr,
                                    Codigo = codigo,
                                    Nombre = nombre,
                                    Peso = peso,
                                    Cl = cl,
                                    FechaDeProduccion = fechaDeProduccion.ToString("yyyy-MM-dd"),
                                    FechaDeCreado = fechaDeCreado.ToString("yyyy-MM-dd hh:mm"),
                                    FechaDeCerrado = fechaDeCerrado.ToString("yyyy-MM-dd"),
                                    Registro = registro,
                                    Estado = estado,
                                };

                                _listaDeCajasConError.Add(lectura);
                            }
                        }
                    }
                    connection.Close();
                }
                return _listaDeCajasConError.OrderByDescending(a => a.FechaDeCreado).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
