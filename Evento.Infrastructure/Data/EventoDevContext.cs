using Evento.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Evento.Infrastructure.Data
{
    public partial class EventoDevContext : DbContext
    {
        public EventoDevContext()
        {
        }

        public EventoDevContext(DbContextOptions<EventoDevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Clasificador> Clasificador { get; set; }
        public virtual DbSet<ClasificadorCiudad> ClasificadorCiudad { get; set; }
        public virtual DbSet<ClasificadorPais> ClasificadorPais { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<Congreso> Congreso { get; set; }
        public virtual DbSet<CongresoUsuario> CongresoUsuario { get; set; }
        public virtual DbSet<DetalleClasificador> DetalleClasificador { get; set; }
        public virtual DbSet<EjeTematico> EjeTematico { get; set; }
        public virtual DbSet<Emprendedor> Emprendedor { get; set; }
        public virtual DbSet<EmprendedorRedSocial> EmprendedorRedSocial { get; set; }
        public virtual DbSet<Expositor> Expositor { get; set; }
        public virtual DbSet<Fecha> Fecha { get; set; }
        public virtual DbSet<Foto> Foto { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<PaginaInformacion> PaginaInformacion { get; set; }
        public virtual DbSet<PaginaMemoria> PaginaMemoria { get; set; }
        public virtual DbSet<Participante> Participante { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<RedSocial> RedSocial { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioRol> UsuarioRol { get; set; }
        public virtual DbSet<Video> Video { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Logo).HasMaxLength(500);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.IdCongresoNavigation)
                    .WithMany(p => p.Categoria)
                    .HasForeignKey(d => d.IdCongreso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Categoria_Congreso");
            });

            modelBuilder.Entity<Clasificador>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            });

            modelBuilder.Entity<ClasificadorCiudad>(entity =>
            {
                entity.Property(e => e.Ciudad)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.ClasificadorCiudad)
                    .HasForeignKey(d => d.IdPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClasificadorCiudad_ClasificadorPais");
            });

            modelBuilder.Entity<ClasificadorPais>(entity =>
            {
                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.Property(e => e.Comenta)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.HasOne(d => d.IdEmprendedorNavigation)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.IdEmprendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comentario_Emprendedor");
            });

            modelBuilder.Entity<Congreso>(entity =>
            {
                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Logo).HasMaxLength(500);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Responsable)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CongresoUsuario>(entity =>
            {
                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.HasOne(d => d.IdCongresoNavigation)
                    .WithMany(p => p.CongresoUsuario)
                    .HasForeignKey(d => d.IdCongreso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CongresoUsuario_Congreso");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.CongresoUsuario)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CongresoUsuario_Usuario");
            });

            modelBuilder.Entity<DetalleClasificador>(entity =>
            {
                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdClasificadorNavigation)
                    .WithMany(p => p.DetalleClasificador)
                    .HasForeignKey(d => d.IdClasificador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleClasificador_Clasificador");
            });

            modelBuilder.Entity<EjeTematico>(entity =>
            {
                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.IdCongresoNavigation)
                    .WithMany(p => p.EjeTematico)
                    .HasForeignKey(d => d.IdCongreso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EjeTematico_Congreso");
            });

            modelBuilder.Entity<Emprendedor>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Latitud)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Longitud)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NombreEmprendimiento)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Ubicacion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Emprendedor)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emprendedor_Categoria");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Emprendedor)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emprendedor_Persona");
            });

            modelBuilder.Entity<EmprendedorRedSocial>(entity =>
            {
                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.HasOne(d => d.IdEmprendedorNavigation)
                    .WithMany(p => p.EmprendedorRedSocial)
                    .HasForeignKey(d => d.IdEmprendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmprendedorRedSocial_Emprendedor");

                entity.HasOne(d => d.IdRedSocialNavigation)
                    .WithMany(p => p.EmprendedorRedSocial)
                    .HasForeignKey(d => d.IdRedSocial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmprendedorRedSocial_RedSocial");
            });

            modelBuilder.Entity<Expositor>(entity =>
            {
                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Institucion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NombreExposicion)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ResumenCv)
                    .IsRequired()
                    .HasColumnName("ResumenCV")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IdEjeTematicoNavigation)
                    .WithMany(p => p.Expositor)
                    .HasForeignKey(d => d.IdEjeTematico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Expositor_EjeTematico");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Expositor)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Expositor_Persona");
            });

            modelBuilder.Entity<Fecha>(entity =>
            {
                entity.Property(e => e.Fecha1)
                    .HasColumnName("Fecha")
                    .HasColumnType("date");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.HasOne(d => d.IdCongresoNavigation)
                    .WithMany(p => p.Fecha)
                    .HasForeignKey(d => d.IdCongreso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fecha_Congreso");
            });

            modelBuilder.Entity<Foto>(entity =>
            {                              
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.HasOne(d => d.IdEmprendedorNavigation)
                    .WithMany(p => p.Foto)
                    .HasForeignKey(d => d.IdEmprendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Foto_Emprendedor");
            });

            modelBuilder.Entity<FotoExp>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.HasOne(d => d.IdExpositorNavigation)
                    .WithMany(p => p.FotoExp)
                    .HasForeignKey(d => d.IdExpositor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FotoExp_Expositor");
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.Property(e => e.CodigoAccesoZoom).HasMaxLength(100);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Horario1)
                    .IsRequired()
                    .HasColumnName("Horario")
                    .HasMaxLength(50);

                entity.Property(e => e.IdReunionZoom).HasMaxLength(100);

                entity.Property(e => e.UrlZoom).HasMaxLength(500);

                entity.HasOne(d => d.IdExpositorNavigation)
                    .WithMany(p => p.Horario)
                    .HasForeignKey(d => d.IdExpositor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Horario_Expositor");

                entity.HasOne(d => d.IdFechaNavigation)
                    .WithMany(p => p.Horario)
                    .HasForeignKey(d => d.IdFecha)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Horario_Fecha");
            });

            modelBuilder.Entity<PaginaInformacion>(entity =>
            {
                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Informacion)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.IdCongresoNavigation)
                    .WithMany(p => p.PaginaInformacion)
                    .HasForeignKey(d => d.IdCongreso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaginaInformacion_Congreso");
            });

            modelBuilder.Entity<PaginaMemoria>(entity =>
            {
                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Memoria)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.IdCongresoNavigation)
                    .WithMany(p => p.PaginaMemoria)
                    .HasForeignKey(d => d.IdCongreso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaginaMemoria_Congreso");
            });

            modelBuilder.Entity<Participante>(entity =>
            {
                entity.Property(e => e.Factura).HasMaxLength(50);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.HasOne(d => d.IdCongresoNavigation)
                    .WithMany(p => p.Participante)
                    .HasForeignKey(d => d.IdCongreso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Participante_Congreso");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Participante)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Participante_Persona");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Fono)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Materno)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.NumDocumento)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Paterno)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.IdCiudadNavigation)
                    .WithMany(p => p.Persona)
                    .HasForeignKey(d => d.IdCiudad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_ClasificadorCiudad");

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.PersonaIdGeneroNavigation)
                    .HasForeignKey(d => d.IdGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_DetalleClasificadorGenero");

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Persona)
                    .HasForeignKey(d => d.IdPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_ClasificadorPais");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.PersonaIdTipoDocumentoNavigation)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_DetalleClasificador");
            });

            modelBuilder.Entity<RedSocial>(entity =>
            {
                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ClaveSalt)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Persona");
            });

            modelBuilder.Entity<UsuarioRol>(entity =>
            {
                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.UsuarioRol)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioRol_Rol");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioRol)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioRol_Usuario");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.HasOne(d => d.IdEmprendedorNavigation)
                    .WithMany(p => p.Video)
                    .HasForeignKey(d => d.IdEmprendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Video_Emprendedor");
            });
        }
    }
}
