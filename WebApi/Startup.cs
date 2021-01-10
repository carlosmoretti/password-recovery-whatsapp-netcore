using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contexto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore;
using Repository;
using Repository.Impl;
using WhatsAppHelper;
using WhatsAppHelper.Impl;

namespace WebApi
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
            services.AddDbContext<ApplicationContext>(e => e.UseMySql(Configuration.GetConnectionString("MysqlDb"), z => z.MigrationsAssembly("WebApi")));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordChangeRegistryRepository, PasswordChangeRegistryRepository>();
            services.AddScoped<IPasswordChangeRegistryRepository, PasswordChangeRegistryRepository>();
            services.AddScoped<IWhatsAppService, WhatsAppService>();

            services.AddSwaggerGen();
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();
            app.UseMiddleware<ExceptionHandling.ExceptionHandler>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
