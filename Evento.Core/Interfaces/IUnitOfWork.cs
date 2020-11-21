using Evento.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Categoria> CategoriaRepository { get; }
        IRepository<Clasificador> ClasificadorRepository { get; }
        IRepository<ClasificadorPais> ClasificadorPaisRepository { get; }
        IRepository<ClasificadorCiudad> ClasificadorCiudadRepository { get; }
        IRepository<Comentario> ComentarioRepository { get; }
        IRepository<CongresoUsuario> CongresoUsuarioRepository { get; }
        IRepository<Congreso> CongresoRepository { get; }
        IRepository<DetalleClasificador> DetalleClasificadorRepository { get; }
        IRepository<EjeTematico> EjeTematicoRepository { get; }
        IRepository<Emprendedor> EmprendedorRepository { get; }
        IRepository<EmprendedorRedSocial> EmprendedorRedSocialRepository { get; }
        IRepository<Expositor> ExpositorRepository { get; }
        IRepository<Fecha> FechaRepository { get; }
        IRepository<Foto> FotoRepository { get; }
        IRepository<FotoExp> FotoExpRepository { get; }
        IRepository<Horario> HorarioRepository { get; }
        IRepository<PaginaInformacion> PaginaInformacionRepository { get; }
        IRepository<PaginaMemoria> PaginaMemoriaRepository { get; }
        IRepository<Participante> ParticipanteRepository { get; }
        IRepository<Persona> PersonaRepository { get; }
        IRepository<Raiting> RaitingRepository { get; }
        IRepository<RedSocial> RedSocialRepository { get; }
        IRepository<Rol> RolRepository { get; }
        IRepository<Usuario> UsuarioRepository { get; }
        IRepository<UsuarioRol> UsuarioRolRepository { get; }
        IRepository<Video> VideoRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
