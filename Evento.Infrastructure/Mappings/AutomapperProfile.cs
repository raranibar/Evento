using AutoMapper;
using Evento.Core.DTO;
using Evento.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Categoria, CategoriaDto>();
            CreateMap<CategoriaDto, Categoria>();

            CreateMap<Clasificador, ClasificadorDto>();
            CreateMap<ClasificadorDto, Clasificador>();

            CreateMap<Comentario, ComentarioDto>();
            CreateMap<ComentarioDto, Comentario>();

            CreateMap<Congreso, CongresoDto>();
            CreateMap<CongresoDto, Congreso>();

            CreateMap<DetalleClasificador, DetalleClasificadorDto>();
            CreateMap<DetalleClasificadorDto, DetalleClasificador>();

            CreateMap<EjeTematico, EjeTematicoDto>();
            CreateMap<EjeTematicoDto, EjeTematico>();

            CreateMap<Emprendedor, EmprendedorDto>();
            CreateMap<EmprendedorDto, Emprendedor>();

            CreateMap<EmprendedorRedSocial, EmprendedorRedSocialDto>();
            CreateMap<EmprendedorRedSocialDto, EmprendedorRedSocial>();

            CreateMap<Expositor, ExpositorDto>();
            CreateMap<ExpositorDto, Expositor>();

            CreateMap<Fecha, FechaDto>();
            CreateMap<FechaDto, Fecha>();

            CreateMap<Foto, FotoDto>();
            CreateMap<FotoDto, Foto>();

            CreateMap<Horario, HorarioDto>();
            CreateMap<HorarioDto, Horario>();

            CreateMap<PaginaInformacion, PaginaInformacionDto>();
            CreateMap<PaginaInformacionDto, PaginaInformacion>();

            CreateMap<PaginaMemoria, PaginaMemoriaDto>();
            CreateMap<PaginaMemoriaDto, PaginaMemoria>();

            CreateMap<Participante, ParticipanteDto>();
            CreateMap<ParticipanteDto, Participante>();

            CreateMap<Persona, PersonaDto>();
            CreateMap<PersonaDto, Persona>();

            CreateMap<RedSocial, RedSocialDto>();
            CreateMap<RedSocialDto, RedSocial>();

            CreateMap<Rol, RolDto>();
            CreateMap<RolDto, Rol>();

            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();

            CreateMap<UsuarioRol, UsuarioRolDto>();
            CreateMap<UsuarioRolDto, UsuarioRol>();
        }            
    }
}
