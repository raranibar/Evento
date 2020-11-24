

using AutoMapper;
using Azure.Storage.Blobs;
using Evento.Core.Interfaces;
using Evento.Infrastructure.Data;
using Evento.Infrastructure.Repositories;
using Evento.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

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
            var conex = Configuration.GetConnectionString("EventoAzurePro");
            var blobs = Configuration.GetConnectionString("EventoStorage");
            services.AddControllers().AddNewtonsoftJson();
            services.AddSingleton(x => new BlobServiceClient(blobs));
            services.AddSingleton<IBlobService, BlobService>();
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
            services.AddTransient<IFotoExpService, FotoExpService>();
            services.AddTransient<IHorarioService, HorarioService>();
            services.AddTransient<IPaginaInformacionService, PaginaInformacionService>();
            services.AddTransient<IPaginaMemoriaService, PaginaMemoriaService>();
            services.AddTransient<IParticipanteService, ParticipanteService>();
            services.AddTransient<IPersonaService, PersonaService>();
            services.AddTransient<IRaitingService, RaitingService>();
            services.AddTransient<IRedSocialService, RedSocialService>();
            services.AddTransient<IRolService, RolService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IUsuarioRolService, UsuarioRolService>();
            services.AddTransient<IVideoService, VideoService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            var secretKey = Configuration["Authentication:SecretKey"];
            var key = Encoding.ASCII.GetBytes(secretKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            
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

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
