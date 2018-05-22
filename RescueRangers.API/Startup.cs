using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;
using System.Reflection;
using RescueRangers.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using System.Data.Common;
using System.Data.SqlClient;
using RescueRangers.API.Services;

namespace RescueRangers.API
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
            services.AddMvc();

            services.AddCors();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            var connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<WebApiDbContext>(options => options.UseSqlite(connectionString));

            services.AddScoped<IAnimalInfoRepository, AnimalInfoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
#pragma warning disable CA1822 // Mark members as static
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
#pragma warning restore CA1822 // Mark members as static
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rescue Rangers");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
            );

            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Entities.Animal, Models.AnimalDto>();
                config.CreateMap<Models.AnimalForCreationDto, Entities.Animal>();
                config.CreateMap<Entities.Adoption, Models.AdopterDto>();
                config.CreateMap<Models.AdoptionDto, Entities.Adoption>();
                config.CreateMap<Models.AdopterDto, Entities.Adopter>();
            });

            app.UseMvc();
        }
    }
}
