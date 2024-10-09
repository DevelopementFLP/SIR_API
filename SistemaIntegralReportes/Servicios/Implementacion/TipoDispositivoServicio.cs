using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaIntegralReportes.DTO.Dispositivos;
using SistemaIntegralReportes.Models.Dispositivos;
using SistemaIntegralReportes.Repositorio.Contrato;
using SistemaIntegralReportes.Servicios.Contrato.Dispositivos;

namespace SistemaIntegralReportes.Servicios.Implementacion
{
    public class TipoDispositivoServicio : ITipoDispositivo
    {
        private readonly IGenericoRepositorio<TipoDispositivos> _modeloRepositorio;
        private readonly IMapper _mapper;

        public TipoDispositivoServicio(IGenericoRepositorio<TipoDispositivos> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<List<TipoDispositivoDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p =>
                p.Nombre.ToLower().Contains(buscar.ToLower())
                );

                List<TipoDispositivoDTO> lista = _mapper.Map<List<TipoDispositivoDTO>>(await consulta.ToListAsync());
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TipoDispositivoDTO> Buscar(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdTipo == id);

                var modeloRetornado = await consulta.FirstOrDefaultAsync();

                if (modeloRetornado != null)
                    return _mapper.Map<TipoDispositivoDTO>(modeloRetornado);
                else
                    throw new TaskCanceledException("No se econtraron coincidencias");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TipoDispositivoDTO> Crear(TipoDispositivoDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<TipoDispositivos>(modelo);
                var respuestaDelModelo = await _modeloRepositorio.Crear(dbModelo);

                if (respuestaDelModelo.IdTipo != 0)
                    return _mapper.Map<TipoDispositivoDTO>(respuestaDelModelo);
                else
                    throw new TaskCanceledException("No se pudo crear");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(TipoDispositivoDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdTipo == modelo.IdTipo);
                var modeloRetornado = await consulta.FirstOrDefaultAsync();

                if (modeloRetornado != null)
                {
                    modeloRetornado.IdTipo = modelo.IdTipo;
                    modeloRetornado.Nombre = modelo.Nombre;
                    modeloRetornado.ComandoInicio = modelo.ComandoInicio;
                    modeloRetornado.ComandoFin = modelo.ComandoFin;


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
                var consulta = _modeloRepositorio.Consultar(p => p.IdTipo == id);
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
