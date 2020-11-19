using AutoMapper;
using Evento.Core.DTO;
using Evento.Core.Entities;
using Evento.Core.Entities.Blob;
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

            CreateMap<CongresoUsuario, CongresoUsuarioDto>();
            CreateMap<CongresoUsuarioDto, CongresoUsuario>();
            CreateMap<CongresoUsuario, PersonaUsuarioDto>();
            CreateMap<PersonaUsuarioDto, CongresoUsuario>();

            CreateMap<Congreso, CongresoDto>();
            CreateMap<CongresoDto, Congreso>();

            CreateMap<DetalleClasificador, DetalleClasificadorDto>();
            CreateMap<DetalleClasificadorDto, DetalleClasificador>();

            CreateMap<EjeTematico, EjeTematicoDto>();
            CreateMap<EjeTematicoDto, EjeTematico>();

            CreateMap<Emprendedor, EmprendedorDto>();
            CreateMap<EmprendedorDto, Emprendedor>();
            CreateMap<Emprendedor, PersonaUsuarioDto>();
            CreateMap<PersonaUsuarioDto, Emprendedor>();



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
            CreateMap<Persona, PersonaUsuarioDto>();
            CreateMap<PersonaUsuarioDto, Persona>();

            CreateMap<RedSocial, RedSocialDto>();
            CreateMap<RedSocialDto, RedSocial>();

            CreateMap<Rol, RolDto>();
            CreateMap<RolDto, Rol>();

            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<Usuario, PersonaUsuarioDto>();
            CreateMap<PersonaUsuarioDto, Usuario>();

            CreateMap<UploadFileRequest, UploadFileDto>();
            CreateMap<UploadFileDto, UploadFileRequest>();

            CreateMap<UsuarioRol, UsuarioRolDto>();
            CreateMap<UsuarioRolDto, UsuarioRol>();
            CreateMap<UsuarioRol, PersonaUsuarioDto>();
            CreateMap<PersonaUsuarioDto, UsuarioRol>();

            CreateMap<Video, VideoDto>();
            CreateMap<VideoDto, Video>();
        }            
    }
}
