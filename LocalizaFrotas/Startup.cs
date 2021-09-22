using Localiza.Frotas.Domain;
using Localiza.Frotas.Infra.Facade;
using Localiza.Frotas.Infra.Repository.EF;
using Localiza.Frotas.Infra.Singleton;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Localiza.Frotas
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Localiza.Frotas", Version = "v1", 
                    Description = "API - Frotas" });

                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                c.IncludeXmlComments(Path.Combine(basePath, fileName));
            });
            /*services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Localiza.Frotas",
                    Description = "API - Frotas",
                    Version = "v1",
                    Contact = new Contact
                    {
                        Name = "Ludmila Reis",
                        Url = "https://github.com/LudmilaReis"
                    }
                });

               var apiPath = Path.Combine(AppContext.BaseDirectory, "Localiza.Frotas.xml");
                c.IncludeXmlComments(apiPath);*/
        
            services.AddTransient<IVeiculoRepository, FrotaRepository>();
            services.AddTransient<IVeiculoDetran, VeiculoDetranFacade>();

            services.AddSingleton<SingletonContainer>();
            services.AddDbContext<FrotaContext>(opt =>
                                               opt.UseInMemoryDatabase("Frota"));

            services.AddHttpClient();

            services.Configure<DetranOptions>(Configuration.GetSection("DetranOptions"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LocalizaFrotas v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
