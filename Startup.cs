using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using mylastplaylist.Data;
using mylastplaylist.Model.Converter;
using mylastplaylist.Repositories;
using mylastplaylist.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylastplaylist
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
            services.AddMvc();
            
            // Temporary Singletons
            services.AddSingleton<IPlaylistService, MemoryPlaylistService>();
            services.AddSingleton<IConverter, Converter>();
            services.AddSingleton<IPlaylistRepository, PlaylistRepository>();

            // Add dbcontext
            services.AddDbContext<PlaylistDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MylastplaylistDatabase"), sqloptions =>
                {

                })
            );

            // Enable CORS
            services.AddCors(c => {
                c.AddPolicy("Alloworigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            // Swagger
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Last Playlist", Version ="v1" }); 
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Swagger
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // Enable CORS
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
