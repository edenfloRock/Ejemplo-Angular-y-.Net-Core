using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WS_VENTAS.Services;

namespace WS_VENTAS
{
    public class Startup
    {

        readonly string BackVentas = "BackVentas";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // LINEAS NECESARIAS PARA PODER ACCEDER A ESTE SERVICIO DESDE ANGULAR
            services.AddCors(options =>
            {
                options.AddPolicy(name: BackVentas,
                                builder =>
                                {
                                    builder.WithHeaders("*"); // PERMITE LA EJECUIÓN DE MÉTODOS POST
                                    builder.WithOrigins("*"); // DESDE DÓNDE SE PUEDE ACCEDER ESTE SERVICO https://www.google.com
                                    builder.WithMethods("*"); // PARA ACCESO POR PUT Y DELETE
                                });
            });

            services.AddControllers();

            // SE AGREGA EL SERVICO DEL USUARIO
            services.AddScoped<IUserService, UserService>();
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

            //SE USA LA VARIALE DEFINIDA
            app.UseCors(BackVentas);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
