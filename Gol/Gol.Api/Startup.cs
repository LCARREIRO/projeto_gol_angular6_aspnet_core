using AutoMapper;
using Gol.Aplicacao.App;
using Gol.Aplicacao.App.Base;
using Gol.Aplicacao.Interfaces;
using Gol.Aplicacao.Interfaces.Base;
using Gol.Dominio.Interfaces.Repositorio;
using Gol.Dominio.Interfaces.Servico;
using Gol.Dominio.Interfaces.Servico.ServicoBase;
using Gol.Dominio.Servico;
using Gol.Dominio.Servico.ServicoBase;
using Gol.InfraData.Contexto;
using Gol.InfraData.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gol.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region Context

            services.AddDbContext<EfDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString(name: "DefaultConnection")));

            #endregion            

            services.AddAutoMapper();

            #region Injeção de Dependência

            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<IAirplaneRepositorio, AirplaneRepositorio>();


            services.AddScoped(typeof(IServicoBase<>), typeof(ServicoBase<>));
            services.AddScoped<IServicoAirplane, ServicoAirplane>();


            services.AddScoped(typeof(IAppServicoBase<>), typeof(AppServicoBase<>));
            services.AddScoped<IAirplaneAppServico, AirplaneAppServico>();


            #endregion

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(builder => builder
               .AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials()
               );
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
