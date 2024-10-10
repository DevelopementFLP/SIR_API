
using Microsoft.EntityFrameworkCore;
using SistemaIntegralReportes.Repositorio.Contrato;
using AutoMapper;
using SistemaIntegralReportes.DTO.Dispositivos;
using SistemaIntegralReportes.Models.Dispositivos;
using SistemaIntegralReportes.Servicios.Contrato.Dispositivos;

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
