

using AutoMapper;
using Evento.Core.Interfaces;
using Evento.Infrastructure.Data;
using Evento.Infrastructure.Repositories;
using Evento.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Evento.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var conex = Configuration.GetConnectionString("EventoAzure");
            services.AddControllers();
            services.AddDbContext<EventoDevContext>(options =>
                options.UseSqlServer(conex));

            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<IClasificadorService, ClasificadorService>();
            services.AddTransient<IClasificadorPaisService, ClasificadorPaisService>();
            services.AddTransient<IClasificadorCiudadService, ClasificadorCiudadService>();
            services.AddTransient<IComentarioService, ComentarioService>();
            services.AddTransient<ICongresoUsuarioService, CongresoUsuarioService>();
            services.AddTransient<ICongresoService, CongresoService>();
            services.AddTransient<IDetalleClasificadorService, DetalleClasificadorService>();
            services.AddTransient<IEjeTematicoService, EjeTematicoService>();
            services.AddTransient<IEmprendedorService, EmprendedorService>();
            services.AddTransient<IEmprendedorRedSocialService, EmprendedorRedSocialService>();
            services.AddTransient<IExpositorService, ExpositorService>();
            services.AddTransient<IFechaService, FechaService>();
            services.AddTransient<IFotoService, FotoService>();
            services.AddTransient<IHorarioService, HorarioService>();
            services.AddTransient<IPaginaInformacionService, PaginaInformacionService>();
            services.AddTransient<IPaginaMemoriaService, PaginaMemoriaService>();
            services.AddTransient<IParticipanteService, ParticipanteService>();
            services.AddTransient<IPersonaService, PersonaService>();
            services.AddTransient<IRedSocialService, RedSocialService>();
            services.AddTransient<IRolService, RolService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IUsuarioRolService, UsuarioRolService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
