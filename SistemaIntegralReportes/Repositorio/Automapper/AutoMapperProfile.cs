﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using SistemaIntegralReportes.Models.Dispositivos;
using SistemaIntegralReportes.DTO.Abasto;
using SistemaIntegralReportes.DTO.Dispositivos;

namespace SistemaIntegralReportes.Repositorio.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Dispositivos, DispositivosDTO>();
            CreateMap<DispositivosDTO, Dispositivos>()
                .ForMember(destino => destino.IdFormatoNavigation, opcion => opcion.Ignore())
                .ForMember(destino => destino.IdTipoNavigation, opcion => opcion.Ignore())
                .ForMember(destino => destino.IdUbicacionNavigation, opcion => opcion.Ignore())
                ;

            CreateMap<Formateos, FormateosDTO>();
            CreateMap<FormateosDTO, Formateos>();

            CreateMap<TipoDispositivos, TipoDispositivoDTO>();
            CreateMap<TipoDispositivoDTO, TipoDispositivos>();

            CreateMap<UbicacionesDispositivos, UbicacionesDispositivosDTO>();
            CreateMap<UbicacionesDispositivosDTO, UbicacionesDispositivos>();
        }
    }
}
