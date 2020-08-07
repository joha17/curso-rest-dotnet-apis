using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using WebApi.Controllers;
using WebApi.Infrastructure.Data.Models;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            ApplicationEnvironment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment ApplicationEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //InCode
            //AppSettings
            //Environment Variable
            var applicationSettings = new ApplicationSettings();
            var appSettingsSection = Configuration.GetSection("AppSettings");
            appSettingsSection.Bind(applicationSettings);
            
            var var1 = Environment.GetEnvironmentVariable("AppSettings__Variable");
            if (!string.IsNullOrEmpty(var1)) 
            {
                applicationSettings.Variable = var1;
            }

            services.AddSingleton(applicationSettings);
            
            services.AddDbContext<AdventureworksContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultDatabase")));


            services.AddScoped<ProductRepository>();

            services.AddCors(options => options.AddDefaultPolicy(builder => {
                
                // Fluent API
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseCors();
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
