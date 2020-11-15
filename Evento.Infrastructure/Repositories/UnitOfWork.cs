using Evento.Core.Entities;
using Evento.Core.Interfaces;
using Evento.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepository<Categoria> _categoriaRepository;
        private readonly IRepository<Clasificador> _clasificadorRepository;
        private readonly IRepository<ClasificadorPais> _clasificadorPaisRepository;
        private readonly IRepository<ClasificadorCiudad> _clasificadorCiudadRepository;
        private readonly IRepository<Comentario> _comentarioRepository;
        private readonly IRepository<CongresoUsuario> _congresoUsuarioRepository;
        private readonly IRepository<Congreso> _congresoRepository;
        private readonly IRepository<DetalleClasificador> _detalleClasificadorRepository;
        private readonly IRepository<EjeTematico> _ejeTematicoRepository;
        private readonly IRepository<Emprendedor> _emprendedorRepository;
        private readonly IRepository<EmprendedorRedSocial> _emprendedorRedSocialRepository;
        private readonly IRepository<Expositor> _expositorRepository;
        private readonly IRepository<Fecha> _fechaRepository;
        private readonly IRepository<Foto> _fotoRepository;
        private readonly IRepository<Horario> _horarioRepository;
        private readonly IRepository<PaginaInformacion> _paginaInformacionRepository;
        private readonly IRepository<PaginaMemoria> _paginaMemoriaRepository;
        private readonly IRepository<Participante> _participanteRepository;
        private readonly IRepository<Persona> _personaRepository;
        private readonly IRepository<RedSocial> _redSocialRepository;
        private readonly IRepository<Rol> _rolRepository;
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IRepository<UsuarioRol> _usuarioRolRepository;

        private readonly EventoDevContext _context;

        public UnitOfWork(EventoDevContext context)
        {
            this._context = context;
        }

        public IRepository<Categoria> CategoriaRepository => _categoriaRepository ?? new BaseRepository<Categoria>(_context);
        public IRepository<Clasificador> ClasificadorRepository => _clasificadorRepository ?? new BaseRepository<Clasificador>(_context);
        public IRepository<ClasificadorPais> ClasificadorPaisRepository => _clasificadorPaisRepository ?? new BaseRepository<ClasificadorPais>(_context);
        public IRepository<ClasificadorCiudad> ClasificadorCiudadRepository => _clasificadorCiudadRepository ?? new BaseRepository<ClasificadorCiudad>(_context);
        public IRepository<Comentario> ComentarioRepository => _comentarioRepository ?? new BaseRepository<Comentario>(_context);
        public IRepository<CongresoUsuario> CongresoUsuarioRepository => _congresoUsuarioRepository ?? new BaseRepository<CongresoUsuario>(_context);
        public IRepository<Congreso> CongresoRepository => _congresoRepository ?? new BaseRepository<Congreso>(_context);
        public IRepository<DetalleClasificador> DetalleClasificadorRepository => _detalleClasificadorRepository ?? new BaseRepository<DetalleClasificador>(_context);
        public IRepository<EjeTematico> EjeTematicoRepository => _ejeTematicoRepository ?? new BaseRepository<EjeTematico>(_context);
        public IRepository<Emprendedor> EmprendedorRepository => _emprendedorRepository ?? new BaseRepository<Emprendedor>(_context);
        public IRepository<EmprendedorRedSocial> EmprendedorRedSocialRepository => _emprendedorRedSocialRepository ?? new BaseRepository<EmprendedorRedSocial>(_context);
        public IRepository<Expositor> ExpositorRepository => _expositorRepository ?? new BaseRepository<Expositor>(_context);
        public IRepository<Fecha> FechaRepository => _fechaRepository ?? new BaseRepository<Fecha>(_context);
        public IRepository<Foto> FotoRepository => _fotoRepository ?? new BaseRepository<Foto>(_context);
        public IRepository<Horario> HorarioRepository => _horarioRepository ?? new BaseRepository<Horario>(_context);
        public IRepository<PaginaInformacion> PaginaInformacionRepository => _paginaInformacionRepository ?? new BaseRepository<PaginaInformacion>(_context);
        public IRepository<PaginaMemoria> PaginaMemoriaRepository => _paginaMemoriaRepository ?? new BaseRepository<PaginaMemoria>(_context);
        public IRepository<Participante> ParticipanteRepository => _participanteRepository ?? new BaseRepository<Participante>(_context);
        public IRepository<Persona> PersonaRepository => _personaRepository ?? new BaseRepository<Persona>(_context);
        public IRepository<RedSocial> RedSocialRepository => _redSocialRepository ?? new BaseRepository<RedSocial>(_context);
        public IRepository<Rol> RolRepository => _rolRepository ?? new BaseRepository<Rol>(_context);
        public IRepository<Usuario> UsuarioRepository => _usuarioRepository ?? new BaseRepository<Usuario>(_context);
        public IRepository<UsuarioRol> UsuarioRolRepository => _usuarioRolRepository ?? new BaseRepository<UsuarioRol>(_context);

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
