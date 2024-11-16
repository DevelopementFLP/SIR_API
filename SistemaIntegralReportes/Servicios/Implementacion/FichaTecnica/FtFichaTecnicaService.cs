using Microsoft.Data.SqlClient;
using SistemaIntegralReportes.DTO.FichaTecnica;
using SistemaIntegralReportes.Servicios.Contrato.FichaTecnica;

namespace SistemaIntegralReportes.Servicios.Implementacion.FichaTecnica
{
    public class FtFichaTecnicaService : IFtFichaTecnica
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public FtFichaTecnicaService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlTestConection");
            _configuration = configuration;
        }

        public async Task<List<FichaTecnicaDTO>> ListaDeFichasTecnicas()
        {
            var resultados = new List<FichaTecnicaDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    // Obtén la consulta SQL desde la configuración
                    string sqlLista = _configuration.GetSection("FichaTecnica:FtListaDeFichasTecnicas").Value;

                    using (SqlCommand command = new SqlCommand(sqlLista, connection))
                    {
                        // Ejecutamos la consulta y leemos los resultados
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var fichaTecnica = new FichaTecnicaDTO
                                {
                                    IdFichaTecnica = reader.GetInt32(reader.GetOrdinal("idFichaTecnica")),
                                    CodigoDeProducto = reader.GetString(reader.GetOrdinal("codigoDeProducto")),
                                    DescripcionDeProducto = reader.GetString(reader.GetOrdinal("descripcionDeProducto")),
                                    NombreDeProducto = reader.GetString(reader.GetOrdinal("nombreDeProducto")),
                                    DescripcionLargaDeProducto = reader.GetString(reader.GetOrdinal("descripcionLargaDeProducto")),
                                    Marca = reader.GetString(reader.GetOrdinal("marca")),
                                    Destino = reader.GetString(reader.GetOrdinal("destino")),
                                    TipoDeUso = reader.GetString(reader.GetOrdinal("tipoDeUso")),
                                    Alergeno = reader.GetString(reader.GetOrdinal("alergeno")),
                                    CondicionAlmacenamiento = reader.GetString(reader.GetOrdinal("condicionAlmacenamiento")),
                                    VidaUtil = reader.GetString(reader.GetOrdinal("vidaUtil")),
                                    TipoDeEnvase = reader.GetString(reader.GetOrdinal("tipoDeEnvase")),
                                    PresentacionDeEnvase = reader.GetString(reader.GetOrdinal("presentacionDeEnvase")),
                                    PesoPromedio = reader.GetDecimal(reader.GetOrdinal("pesoPromedio")),
                                    UnidadesPorCaja = reader.GetInt32(reader.GetOrdinal("unidadesPorCaja")),
                                    Dimensiones = reader.GetString(reader.GetOrdinal("dimensiones")),
                                    Idioma = reader.GetString(reader.GetOrdinal("idioma")),
                                    GrasaVisible = reader.GetString(reader.GetOrdinal("grasaVisible")),
                                    EspesorCobertura = reader.GetString(reader.GetOrdinal("espesorCobertura")),
                                    Ganglios = reader.GetString(reader.GetOrdinal("ganglios")),
                                    Hematomas = reader.GetString(reader.GetOrdinal("hematomas")),
                                    HuesosCartilagos = reader.GetString(reader.GetOrdinal("huesosCartilagos")),
                                    ElementosExtranos = reader.GetString(reader.GetOrdinal("elementosExtranos")),
                                    Color = reader.GetString(reader.GetOrdinal("color")),
                                    Olor = reader.GetString(reader.GetOrdinal("olor")),
                                    Ph = reader.GetString(reader.GetOrdinal("ph")),
                                    AerobiosMesofilosTotales = reader.GetString(reader.GetOrdinal("aerobiosMesofilosTotales")),
                                    Enterobacterias = reader.GetString(reader.GetOrdinal("enterobacterias")),
                                    Stec0157 = reader.GetString(reader.GetOrdinal("stec0157")),
                                    StecNo0157 = reader.GetString(reader.GetOrdinal("stecNo0157")),
                                    Salmonella = reader.GetString(reader.GetOrdinal("salmonella")),
                                    Estafilococos = reader.GetString(reader.GetOrdinal("estafilococos")),
                                    Pseudomonas = reader.GetString(reader.GetOrdinal("pseudomonas")),
                                    EscherichiaColi = reader.GetString(reader.GetOrdinal("escherichiaColi")),
                                    ColiformesTotales = reader.GetString(reader.GetOrdinal("coliformesTotales")),
                                    ColiformesFecales = reader.GetString(reader.GetOrdinal("coliformesFecales")),
                                    Observacion = reader.GetString(reader.GetOrdinal("observacion")),
                                    ElaboradoPor = reader.GetString(reader.GetOrdinal("elaboradoPor")),
                                    AprobadoPor = reader.GetString(reader.GetOrdinal("aprobadoPor")),
                                    FechaCreacion = reader.GetString(reader.GetOrdinal("fechaCreacion")),
                                };

                                resultados.Add(fichaTecnica);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las fichas técnicas.", ex);
            }

            return resultados.OrderByDescending(id => id.IdFichaTecnica).ToList();
        }

        public async Task<List<FichaTecnicaDTO>> Buscar(string codigoDeProducto)
        {
            var resultados = new List<FichaTecnicaDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string sqlBuscar = _configuration.GetSection("FichaTecnica:FtBuscarFichaTecnica").Value;

                    using (SqlCommand command = new SqlCommand(sqlBuscar, connection))
                    {
                        command.Parameters.AddWithValue("@codigoDeProducto", "%" + codigoDeProducto + "%");

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var fichaTecnica = new FichaTecnicaDTO
                                {
                                    IdFichaTecnica = reader.GetInt32(reader.GetOrdinal("idFichaTecnica")),
                                    CodigoDeProducto = reader.GetString(reader.GetOrdinal("codigoDeProducto")),
                                    DescripcionDeProducto = reader.GetString(reader.GetOrdinal("descripcionDeProducto")),
                                    NombreDeProducto = reader.GetString(reader.GetOrdinal("nombreDeProducto")),
                                    DescripcionLargaDeProducto = reader.GetString(reader.GetOrdinal("descripcionLargaDeProducto")),
                                    Marca = reader.GetString(reader.GetOrdinal("marca")),
                                    Destino = reader.GetString(reader.GetOrdinal("destino")),
                                    TipoDeUso = reader.GetString(reader.GetOrdinal("tipoDeUso")),
                                    Alergeno = reader.GetString(reader.GetOrdinal("alergeno")),
                                    CondicionAlmacenamiento = reader.GetString(reader.GetOrdinal("condicionAlmacenamiento")),
                                    VidaUtil = reader.GetString(reader.GetOrdinal("vidaUtil")),
                                    TipoDeEnvase = reader.GetString(reader.GetOrdinal("tipoDeEnvase")),
                                    PresentacionDeEnvase = reader.GetString(reader.GetOrdinal("presentacionDeEnvase")),
                                    PesoPromedio = reader.GetDecimal(reader.GetOrdinal("pesoPromedio")),
                                    UnidadesPorCaja = reader.GetInt32(reader.GetOrdinal("unidadesPorCaja")),
                                    Dimensiones = reader.GetString(reader.GetOrdinal("dimensiones")),
                                    Idioma = reader.GetString(reader.GetOrdinal("idioma")),
                                    GrasaVisible = reader.GetString(reader.GetOrdinal("grasaVisible")),
                                    EspesorCobertura = reader.GetString(reader.GetOrdinal("espesorCobertura")),
                                    Ganglios = reader.GetString(reader.GetOrdinal("ganglios")),
                                    Hematomas = reader.GetString(reader.GetOrdinal("hematomas")),
                                    HuesosCartilagos = reader.GetString(reader.GetOrdinal("huesosCartilagos")),
                                    ElementosExtranos = reader.GetString(reader.GetOrdinal("elementosExtranos")),
                                    Color = reader.GetString(reader.GetOrdinal("color")),
                                    Olor = reader.GetString(reader.GetOrdinal("olor")),
                                    Ph = reader.GetString(reader.GetOrdinal("ph")),
                                    AerobiosMesofilosTotales = reader.GetString(reader.GetOrdinal("aerobiosMesofilosTotales")),
                                    Enterobacterias = reader.GetString(reader.GetOrdinal("enterobacterias")),
                                    Stec0157 = reader.GetString(reader.GetOrdinal("stec0157")),
                                    StecNo0157 = reader.GetString(reader.GetOrdinal("stecNo0157")),
                                    Salmonella = reader.GetString(reader.GetOrdinal("salmonella")),
                                    Estafilococos = reader.GetString(reader.GetOrdinal("estafilococos")),
                                    Pseudomonas = reader.GetString(reader.GetOrdinal("pseudomonas")),
                                    EscherichiaColi = reader.GetString(reader.GetOrdinal("escherichiaColi")),
                                    ColiformesTotales = reader.GetString(reader.GetOrdinal("coliformesTotales")),
                                    ColiformesFecales = reader.GetString(reader.GetOrdinal("coliformesFecales")),
                                    Observacion = reader.GetString(reader.GetOrdinal("observacion")),
                                    ElaboradoPor = reader.GetString(reader.GetOrdinal("elaboradoPor")),
                                    AprobadoPor = reader.GetString(reader.GetOrdinal("aprobadoPor")),
                                    FechaCreacion = reader.GetString(reader.GetOrdinal("fechaCreacion")),
                                };

                                resultados.Add(fichaTecnica);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar la ficha técnica.", ex);
            }

            return resultados;
        }




        public async Task<FichaTecnicaDTO> Crear(FichaTecnicaDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string sqlCrear = _configuration.GetSection("FichaTecnica:FtCrearFichaTecnica").Value;

                    using (SqlCommand command = new SqlCommand(sqlCrear, connection))
                    {
                        command.Parameters.AddWithValue("@codigoDeProducto", modelo.CodigoDeProducto);
                        command.Parameters.AddWithValue("@nombreDeProducto", modelo.NombreDeProducto);  
                        command.Parameters.AddWithValue("@descripcionDeProducto", modelo.DescripcionDeProducto);  
                        command.Parameters.AddWithValue("@descripcionLargaDeProducto", modelo.DescripcionLargaDeProducto);  
                        command.Parameters.AddWithValue("@marca", modelo.Marca);
                        command.Parameters.AddWithValue("@destino", modelo.Destino);  
                        command.Parameters.AddWithValue("@tipoDeUso", modelo.TipoDeUso);
                        command.Parameters.AddWithValue("@alergeno", modelo.Alergeno);
                        command.Parameters.AddWithValue("@condicionAlmacenamiento", modelo.CondicionAlmacenamiento);
                        command.Parameters.AddWithValue("@vidaUtil", modelo.VidaUtil);
                        command.Parameters.AddWithValue("@tipoDeEnvase", modelo.TipoDeEnvase);
                        command.Parameters.AddWithValue("@presentacionDeEnvase", modelo.PresentacionDeEnvase);
                        command.Parameters.AddWithValue("@pesoPromedio", modelo.PesoPromedio);
                        command.Parameters.AddWithValue("@unidadesPorCaja", modelo.UnidadesPorCaja);
                        command.Parameters.AddWithValue("@dimensiones", modelo.Dimensiones);
                        command.Parameters.AddWithValue("@idioma", modelo.Idioma);
                        command.Parameters.AddWithValue("@grasaVisible", modelo.GrasaVisible);
                        command.Parameters.AddWithValue("@espesorCobertura", modelo.EspesorCobertura);
                        command.Parameters.AddWithValue("@ganglios", modelo.Ganglios);
                        command.Parameters.AddWithValue("@hematomas", modelo.Hematomas);
                        command.Parameters.AddWithValue("@huesosCartilagos", modelo.HuesosCartilagos);
                        command.Parameters.AddWithValue("@elementosExtranos", modelo.ElementosExtranos);
                        command.Parameters.AddWithValue("@color", modelo.Color);
                        command.Parameters.AddWithValue("@olor", modelo.Olor);
                        command.Parameters.AddWithValue("@ph", modelo.Ph);
                        command.Parameters.AddWithValue("@aerobiosMesofilosTotales", modelo.AerobiosMesofilosTotales);
                        command.Parameters.AddWithValue("@enterobacterias", modelo.Enterobacterias);
                        command.Parameters.AddWithValue("@stec0157", modelo.Stec0157);
                        command.Parameters.AddWithValue("@stecNo0157", modelo.StecNo0157);
                        command.Parameters.AddWithValue("@salmonella", modelo.Salmonella);
                        command.Parameters.AddWithValue("@estafilococos", modelo.Estafilococos);
                        command.Parameters.AddWithValue("@pseudomonas", modelo.Pseudomonas);
                        command.Parameters.AddWithValue("@escherichiaColi", modelo.EscherichiaColi);
                        command.Parameters.AddWithValue("@coliformesTotales", modelo.ColiformesTotales);
                        command.Parameters.AddWithValue("@coliformesFecales", modelo.ColiformesFecales);
                        command.Parameters.AddWithValue("@observacion", modelo.Observacion);  
                        command.Parameters.AddWithValue("@elaboradoPor", modelo.ElaboradoPor);
                        command.Parameters.AddWithValue("@aprobadoPor", modelo.AprobadoPor);
                        command.Parameters.AddWithValue("@fechaCreacion", modelo.FechaCreacion);

                        int rowsAffected = await command.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)
                        {
                            return modelo;
                        }
                        else
                        {
                            throw new TaskCanceledException("No se pudo crear la ficha técnica.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la ficha técnica.", ex);
            }
        }

        public async Task<bool> Editar(FichaTecnicaDTO modelo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string sqlEditar = _configuration.GetSection("FichaTecnica:FtEditarFichaTecnica").Value;

                    using (SqlCommand command = new SqlCommand(sqlEditar, connection))
                    {
                        command.Parameters.AddWithValue("@idFichaTecnica", modelo.IdFichaTecnica);
                        command.Parameters.AddWithValue("@descripcionDeProducto", modelo.DescripcionDeProducto);
                        command.Parameters.AddWithValue("@nombreDeProducto", modelo.NombreDeProducto);
                        command.Parameters.AddWithValue("@descripcionLargaDeProducto", modelo.DescripcionLargaDeProducto);
                        command.Parameters.AddWithValue("@marca", modelo.Marca);
                        command.Parameters.AddWithValue("@destino", modelo.Destino);
                        command.Parameters.AddWithValue("@tipoDeUso", modelo.TipoDeUso);
                        command.Parameters.AddWithValue("@alergeno", modelo.Alergeno);
                        command.Parameters.AddWithValue("@condicionAlmacenamiento", modelo.CondicionAlmacenamiento);
                        command.Parameters.AddWithValue("@vidaUtil", modelo.VidaUtil);
                        command.Parameters.AddWithValue("@tipoDeEnvase", modelo.TipoDeEnvase);
                        command.Parameters.AddWithValue("@presentacionDeEnvase", modelo.PresentacionDeEnvase);
                        command.Parameters.AddWithValue("@pesoPromedio", modelo.PesoPromedio);
                        command.Parameters.AddWithValue("@unidadesPorCaja", modelo.UnidadesPorCaja);
                        command.Parameters.AddWithValue("@dimensiones", modelo.Dimensiones);
                        command.Parameters.AddWithValue("@idioma", modelo.Idioma);
                        command.Parameters.AddWithValue("@grasaVisible", modelo.GrasaVisible);
                        command.Parameters.AddWithValue("@espesorCobertura", modelo.EspesorCobertura);
                        command.Parameters.AddWithValue("@ganglios", modelo.Ganglios);
                        command.Parameters.AddWithValue("@hematomas", modelo.Hematomas);
                        command.Parameters.AddWithValue("@huesosCartilagos", modelo.HuesosCartilagos);
                        command.Parameters.AddWithValue("@elementosExtranos", modelo.ElementosExtranos);
                        command.Parameters.AddWithValue("@color", modelo.Color);
                        command.Parameters.AddWithValue("@olor", modelo.Olor);
                        command.Parameters.AddWithValue("@ph", modelo.Ph);
                        command.Parameters.AddWithValue("@aerobiosMesofilosTotales", modelo.AerobiosMesofilosTotales);
                        command.Parameters.AddWithValue("@enterobacterias", modelo.Enterobacterias);
                        command.Parameters.AddWithValue("@stec0157", modelo.Stec0157);
                        command.Parameters.AddWithValue("@stecNo0157", modelo.StecNo0157);
                        command.Parameters.AddWithValue("@salmonella", modelo.Salmonella);
                        command.Parameters.AddWithValue("@estafilococos", modelo.Estafilococos);
                        command.Parameters.AddWithValue("@pseudomonas", modelo.Pseudomonas);
                        command.Parameters.AddWithValue("@escherichiaColi", modelo.EscherichiaColi);
                        command.Parameters.AddWithValue("@coliformesTotales", modelo.ColiformesTotales);
                        command.Parameters.AddWithValue("@coliformesFecales", modelo.ColiformesFecales);
                        command.Parameters.AddWithValue("@observacion", modelo.Observacion);
                        command.Parameters.AddWithValue("@elaboradoPor", modelo.ElaboradoPor);
                        command.Parameters.AddWithValue("@aprobadoPor", modelo.AprobadoPor);
                        command.Parameters.AddWithValue("@fechaCreacion", modelo.FechaCreacion);

                        int rowsAffected = await command.ExecuteNonQueryAsync();

                        return rowsAffected > 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar la ficha técnica.", ex);
            }
        }


        public async Task<bool> Eliminar(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string sqlEliminar = _configuration.GetSection("FichaTecnica:FtEliminarFichaTecnica").Value;

                    using (SqlCommand command = new SqlCommand(sqlEliminar, connection))
                    {
                        // Añadimos el parámetro para eliminar por id
                        command.Parameters.AddWithValue("@idFichaTecnica", id);

                        int rowsAffected = await command.ExecuteNonQueryAsync();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la ficha técnica.", ex);
            }
        }
    }
}
