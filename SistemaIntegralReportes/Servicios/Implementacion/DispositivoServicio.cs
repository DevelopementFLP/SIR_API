using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using SistemaIntegralReportes.Models.Dispositivos;
using SistemaIntegralReportes.Models.StockCajas;

using SistemaIntegralReportes.Repositorio.Contrato;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.Servicios.Contrato;
using AutoMapper;

namespace SistemaIntegralReportes.Servicios.Implementacion
{
    public class DispositivoServicio : IDispositivo
    {
        private readonly IGenericoRepositorio<Dispositivos> _modeloRepositorio;
        private readonly IMapper _mapper;

        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public DispositivoServicio(IGenericoRepositorio<Dispositivos> modeloRepositorio, IMapper mapper, IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SqlTestConection");

            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<List<DispositivosDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p =>
                p.Descripcion.ToLower().Contains(buscar.ToLower())
                );

                consulta = consulta.Include(formato => formato.IdFormatoNavigation);
                consulta = consulta.Include(tipo => tipo.IdTipoNavigation);
                consulta = consulta.Include(ubicacion => ubicacion.IdUbicacionNavigation);

                List<DispositivosDTO> lista = _mapper.Map<List<DispositivosDTO>>(await consulta.ToListAsync());
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DispositivosDTO> Buscar(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdDispositivo == id);
                //consulta = consulta.Include(c => c.IdTipo);
                var modeloRetornado = await consulta.FirstOrDefaultAsync();


                if (modeloRetornado != null)
                {
                    return _mapper.Map<DispositivosDTO>(modeloRetornado);
                }
                else
                {
                    throw new TaskCanceledException("No se econtraron coincidencias");
                }                                                        
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //List<Dispositivos> dispositivos = new List<Dispositivos>();

            //using (SqlConnection connection = new SqlConnection(_connectionString))
            //{
            //    await connection.OpenAsync();

            //    var queryExecute = _configuration.GetSection("Dispositivos:GetDispositivos").Value.ToString();

            //    using (SqlCommand command = new SqlCommand(queryExecute, connection))
            //    {
            //        command.Parameters.AddWithValue("@idDispositivo", id);

            //        using (SqlDataReader reader = await command.ExecuteReaderAsync())
            //        {
            //            while (await reader.ReadAsync())
            //            {
            //                Dispositivos dispositivo = new Dispositivos
            //                {
            //                    _idDispositivo = reader.GetInt32(0),
            //                    _nombreDeDispositivo = reader.GetString(1),
            //                    _ipDispositivo = reader.GetString(2),
            //                    _puertoDispositivo = reader.GetInt32(3),
            //                    _descripcionDispositivo = reader.GetString(4),
            //                    _estadoDispositivo = reader.GetBoolean(5),
            //                    _idUbicacionDispositivo = reader.GetInt32(6),
            //                    _idFormatoDispositivo = reader.GetInt32(7)
            //                };

            //                dispositivos.Add(dispositivo);
            //            }
            //        }
            //    }
            //}
            //return dispositivos;
        }

        public async Task<DispositivosDTO> Crear(DispositivosDTO modelo)
        {

            try
            {
                var dbModelo = _mapper.Map<Dispositivos>(modelo);
                var respuestaDelModelo = await _modeloRepositorio.Crear(dbModelo);

                if (respuestaDelModelo.IdDispositivo != 0)
                    return _mapper.Map<DispositivosDTO>(respuestaDelModelo);
                else
                    throw new TaskCanceledException("No se pudo crear");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //try
            //{
            //    using (SqlConnection connection = new SqlConnection(_connectionString))
            //    {
            //        await connection.OpenAsync();

            //        var queryExecute = _configuration.GetSection("Dispositivos:CreateDispositivos").Value;

            //        using (SqlCommand command = new SqlCommand(queryExecute, connection))
            //        {
            //            command.Parameters.AddWithValue("@nombreDeDispositivo", modelo._nombreDeDispositivo);
            //            command.Parameters.AddWithValue("@ipDispositivo", modelo._ipDispositivo);
            //            command.Parameters.AddWithValue("@puertoDispositivo", modelo._puertoDispositivo);
            //            command.Parameters.AddWithValue("@descripcionDispositivo", modelo._descripcionDispositivo);
            //            command.Parameters.AddWithValue("@estadoDispositivo", modelo._estadoDispositivo);
            //            command.Parameters.AddWithValue("@idTipoDispositivo", modelo._idTipoDispositivo);
            //            command.Parameters.AddWithValue("@idUbicacionDispositivo", modelo._idUbicacionDispositivo);
            //            command.Parameters.AddWithValue("@idFormatoDispositivo", modelo._idFormatoDispositivo);

            //            // Ejecutar el INSERT usando ExecuteNonQueryAsync
            //            await command.ExecuteNonQueryAsync();

            //            return modelo;
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }

        public async Task<bool> Editar(DispositivosDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdDispositivo == modelo.IdDispositivo);
                var modeloRetornado = await consulta.FirstOrDefaultAsync();

                if (modeloRetornado != null)
                {
                    modeloRetornado.Nombre = modelo.Nombre;
                    modeloRetornado.Ip = modelo.Ip;
                    modeloRetornado.Puerto = modelo.Puerto;
                    modeloRetornado.Descripcion = modelo.Descripcion;
                    modeloRetornado.Activo = modelo.Activo;
                    modeloRetornado.IdTipo = modelo.IdTipo;
                    modeloRetornado.IdFormato = modelo.IdFormato;


                    var respuesta = await _modeloRepositorio.Editar(modeloRetornado);

                    if (!respuesta)
                    {
                        throw new TaskCanceledException("No se pudo editar");
                    }

                    return respuesta;
                }
                else
                {
                    throw new TaskCanceledException("No se econtraron resultados");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //try
            //{
            //    using (SqlConnection connection = new SqlConnection(_connectionString))
            //    {
            //        await connection.OpenAsync();

            //        var updateQuery = _configuration.GetSection("Dispositivos:UpdateDispositivo").Value;

            //        using (SqlCommand command = new SqlCommand(updateQuery, connection))
            //        {
            //            command.Parameters.AddWithValue("@idDispositivo", modelo._idDispositivo);
            //            command.Parameters.AddWithValue("@nombreDeDispositivo", modelo._nombreDeDispositivo);
            //            command.Parameters.AddWithValue("@ipDispositivo", modelo._ipDispositivo);
            //            command.Parameters.AddWithValue("@puertoDispositivo", modelo._puertoDispositivo);
            //            command.Parameters.AddWithValue("@descripcionDispositivo", modelo._descripcionDispositivo);
            //            command.Parameters.AddWithValue("@estadoDispositivo", modelo._estadoDispositivo);
            //            command.Parameters.AddWithValue("@idTipoDispositivo", modelo._idTipoDispositivo);
            //            command.Parameters.AddWithValue("@idUbicacionDispositivo", modelo._idUbicacionDispositivo);
            //            command.Parameters.AddWithValue("@idFormatoDispositivo", modelo._idFormatoDispositivo);

            //            // Ejecutar el UPDATE 
            //            int rowsAffected = await command.ExecuteNonQueryAsync();

            //            return true;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error al actualizar dispositivo: {ex.Message}");
            //    throw;
            //}
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdDispositivo == id);
                var modeloRetornado = await consulta.FirstOrDefaultAsync();

                if (modeloRetornado != null)
                {
                    var respuesta = await _modeloRepositorio.Eliminar(modeloRetornado);
                    if (!respuesta)
                    {
                        throw new TaskCanceledException("No se pudo eliminar");
                    }

                    return respuesta;
                }
                else
                    throw new TaskCanceledException("No se econtraron resultados");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
