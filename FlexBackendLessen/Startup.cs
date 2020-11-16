using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FlexBackendLessen.Controllers;
using FlexBackendLessen.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FlexBackendLessen
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
            // services.Add(new ServiceDescriptor(typeof(IMyLogger), typeof(MyLogger), ServiceLifetime.Transient));
            // services.Add(new ServiceDescriptor(typeof(IEngine), typeof(Engine), ServiceLifetime.Scoped));
            // services.Add(new ServiceDescriptor(typeof(Car), typeof(Car), ServiceLifetime.Scoped));


            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddControllers();

            services.AddDbContext<WebshopContext>(builder =>
            {
                builder.UseNpgsql("Host=localhost;Database=webshop;Port=5433;Username=postgres;Password=postgres");
                builder.EnableSensitiveDataLogging();
            });

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WebshopContext db)
        {
            //RequestPipelineExample(app, env);

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            SeedDatabase.Seed(db);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void RequestPipelineExample(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //example of request pipeline
            app.Use(async (context, next) =>
            {
                string url = context.Request.Path.Value.ToLower();
                if (url == "/weatherforecast")
                {
                    //WeatherForecastController wfc = new WeatherForecastController(null);
                    //await context.Response.WriteAsync(JsonSerializer.Serialize(wfc.Get()));
                }
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Joris hier");
                await context.Response.CompleteAsync();
            });


        }
    }
}
