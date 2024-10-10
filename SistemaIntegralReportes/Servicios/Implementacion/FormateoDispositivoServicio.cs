using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaIntegralReportes.DTO.Dispositivos;
using SistemaIntegralReportes.Models.Dispositivos;
using SistemaIntegralReportes.Repositorio.Contrato;
using SistemaIntegralReportes.Servicios.Contrato.Dispositivos;

namespace SistemaIntegralReportes.Servicios.Implementacion
{
    public class FormateoDispositivoServicio : IFormateoDispositivo
    {
        private readonly IGenericoRepositorio<Formateos> _modeloRepositorio;
        private readonly IMapper _mapper;

        public FormateoDispositivoServicio(IGenericoRepositorio<Formateos> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<List<FormateosDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p =>
                p.ErrorLectura.ToLower().Contains(buscar.ToLower())
                );

                List<FormateosDTO> lista = _mapper.Map<List<FormateosDTO>>(await consulta.ToListAsync());
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FormateosDTO> Buscar(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdFormato == id);
                //Incluir el dato de la clase asociada
                //consulta = consulta.Include(c => c.IdTipo);
                var modeloRetornado = await consulta.FirstOrDefaultAsync();


                if (modeloRetornado != null)
                    return _mapper.Map<FormateosDTO>(modeloRetornado);
                else
                    throw new TaskCanceledException("No se econtraron coincidencias");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FormateosDTO> Crear(FormateosDTO modelo)
        {

            try
            {
                var dbModelo = _mapper.Map<Formateos>(modelo);
                var respuestaDelModelo = await _modeloRepositorio.Crear(dbModelo);

                if (respuestaDelModelo.IdFormato != 0)
                    return _mapper.Map<FormateosDTO>(respuestaDelModelo);
                else
                    throw new TaskCanceledException("No se pudo crear");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(FormateosDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdFormato == modelo.IdFormato);
                var modeloRetornado = await consulta.FirstOrDefaultAsync();

                if (modeloRetornado != null)
                {
                    modeloRetornado.IdFormato = modelo.IdFormato;
                    modeloRetornado.SubstringDesde = modelo.SubstringDesde;
                    modeloRetornado.SubstringHasta = modelo.SubstringHasta;
                    modeloRetornado.ErrorLectura = modelo.ErrorLectura;


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
                var consulta = _modeloRepositorio.Consultar(p => p.IdFormato == id);
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
