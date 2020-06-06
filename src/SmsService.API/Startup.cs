using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using SmsService.API.Infrastructure;
using SmsService.Model;
using SmsService.Services.Commands;

namespace WebApplication1
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
            services.ConfigureServices();

            services.AddLogging(cfg =>
            {
                cfg.ClearProviders();
                cfg.AddNLog(Configuration);
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("SMS API", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "SMS Service API" });
            });
            services.AddDbContext<SMSContext>(options =>
            {
                options.UseMySql(Configuration["ConnectionString"]);
                //options.UseMySql("Server=host.docker.internal;Database=sms_service;Uid=root;Pwd=root;");
            });
            services.AddMediatR(typeof(SendSMSCommand).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(setup =>
            {
                setup.SwaggerEndpoint("/swagger.json", "Demo");
            });
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
