using ClientApp.API.ClientApp.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClientApp.API.Services.Logger;
using ClientApp.API.Services.MailService;

namespace ClientApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlite()
                .AddDbContext<ApplicationContext>(opt =>
                    opt.UseSqlite(Configuration.GetConnectionString("SqliteConnection")));

            services.AddControllers();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientGroupRepository, ClientGroupRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ICardMetadataRepository, CardMetadataRepository>();
            services.AddScoped<INotificationSubscribersRepository, NotificationSubscribersRepository>();

            services.AddAutoMapper(typeof(Startup));
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddTransient<IMailService, MailService>();

            services.AddResponseCaching();
            services.AddMemoryCache(o => {
                o.SizeLimit = 1024;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseResponseCaching();          
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
