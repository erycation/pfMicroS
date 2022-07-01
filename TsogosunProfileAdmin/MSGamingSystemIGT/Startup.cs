using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using tsogosun.com.GamingSystemIGT.Shared;
using tsogosun.com.MSGamingSystemIGT.Service;
using tsogosun.com.MSGamingSystemIGT.Service.Interface;
using tsogosun.com.MSGamingSystemIGT.Shared;
using tsogosun.com.MSGamingSystemIGT.Shared.Helpers;

namespace MSGamingSystemIGT
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly string _policyName = "CorsPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Micro Service GamingSystem IGT", Version = "v1" });
            });

            services.AddCors(opt =>
            {
                opt.AddPolicy(name: _policyName, builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
         

            services.AddScoped<IPlayerProfileService, PlayerProfileService>();
            services.AddScoped<IAppSettingsConfigService, AppSettingsConfigService>();
            services.AddScoped<IPatronRankingService, PatronRankingService>();
            services.AddScoped<IIGTPlayerInfoService, IGTPlayerInfoService>();
            services.AddScoped<ICountryInfoService, CountryInfoService>();

            services.AddIGTService();
        }

       
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MSGamingSystemIGT v1"));
           // }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(_policyName);
            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
