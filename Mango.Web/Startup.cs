using System;
using System.Text.Json.Serialization;
using Mango.Application;
using Mango.Attributes;
using Mango.Persistence;
using Mango.Configuration;
using Mango.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace Mango
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options => 
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.ConfigureSwagger();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.RegisterServices();
            services.RegisterPersistence();
            
            services.AddScoped<RequestLimitFilterAttribute>();
            services.AddScoped<IRequestLimitService, RequestLimitService>();
            services.Configure<RequestLimitOptions>(_configuration.GetSection(nameof(RequestLimitOptions)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Credit Line Service");
                });
        }
    }
}