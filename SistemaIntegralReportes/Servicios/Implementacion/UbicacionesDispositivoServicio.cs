using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaIntegralreportes.DTO;
using SistemaIntegralReportes.Models.Dispositivos;
using SistemaIntegralReportes.Repositorio.Contrato;
using SistemaIntegralReportes.Servicios.Contrato;

namespace SistemaIntegralReportes.Servicios.Implementacion
{
    public class UbicacionesDispositivoServicio : IUbicacionesDispositivo
    {
        private readonly IGenericoRepositorio<UbicacionesDispositivos> _modeloRepositorio;
        private readonly IMapper _mapper;

        public UbicacionesDispositivoServicio(IGenericoRepositorio<UbicacionesDispositivos> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<List<UbicacionesDispositivosDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p =>
                p.Descripcion.ToLower().Contains(buscar.ToLower())
                );

                List<UbicacionesDispositivosDTO> lista = _mapper.Map<List<UbicacionesDispositivosDTO>>(await consulta.ToListAsync());
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UbicacionesDispositivosDTO> Buscar(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdUbicacion == id);

                var modeloRetornado = await consulta.FirstOrDefaultAsync();

                if (modeloRetornado != null)
                    return _mapper.Map<UbicacionesDispositivosDTO>(modeloRetornado);
                else
                    throw new TaskCanceledException("No se econtraron coincidencias");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UbicacionesDispositivosDTO> Crear(UbicacionesDispositivosDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<UbicacionesDispositivos>(modelo);
                var respuestaDelModelo = await _modeloRepositorio.Crear(dbModelo);

                if (respuestaDelModelo.IdUbicacion != 0)
                    return _mapper.Map<UbicacionesDispositivosDTO>(respuestaDelModelo);
                else
                    throw new TaskCanceledException("No se pudo crear");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(UbicacionesDispositivosDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdUbicacion == modelo.IdUbicacion);
                var modeloRetornado = await consulta.FirstOrDefaultAsync();

                if (modeloRetornado != null)
                {
                    modeloRetornado.Nombre = modelo.Nombre;
                    modeloRetornado.Descripcion = modelo.Descripcion;
                    modeloRetornado.Activo = modelo.Activo;

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
                var consulta = _modeloRepositorio.Consultar(p => p.IdUbicacion == id);
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
