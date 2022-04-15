using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using N3O.Challenge.Domain;
using N3O.Challenge.Domain.Cache;
using N3O.Challenge.Domain.Entities;
using N3O.Challenge.Domain.MappingProfiles;
using System;
using System.Reflection;

namespace N3O.Challenge.Web {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            services.AddMvc();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1",
                             new OpenApiInfo {
                                 Title = "My API", Version = "v1"
                             });
            });

            

            services.AddSingleton<ISimpleCache<Guid, User>, SimpleCache<Guid, User>>();
            services.AddMediatR(typeof(Mediatrstartup).Assembly);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}