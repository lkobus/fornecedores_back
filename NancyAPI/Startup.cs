using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.SQLLite;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Interfaces.Services;
using ListagemFornecedores.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NancyAPI.DI;
using NHibernate;
using NHibernate.Cfg;
using Ninject;

namespace NancyAPI
{
    public class Startup
    {

        public static StandardKernel NINJECT;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            NINJECT = new StandardKernel(new ApplicationModule());

            services.AddControllers();
            /*
            services.AddScoped(factory =>
            {
                return _sessionFactory.OpenSession();
            });
            */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors (builder => builder
                 .AllowAnyOrigin ()
                 .AllowAnyHeader ()
                 .AllowAnyMethod ());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapGet("/cadastra", async context => {

                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
