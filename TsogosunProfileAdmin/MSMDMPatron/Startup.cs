
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using tsogosun.com.MSMDMPatron.App_Start;
using tsogosun.com.MSMDMPatron.Repository;
using tsogosun.com.MSMDMPatron.Repository.Interface;
using tsogosun.com.MSMDMPatron.Service;
using tsogosun.com.MSMDMPatron.Service.Interface;
using tsogosun.com.MSMDMPatron.Shared;
using tsogosun.com.MSMDMPatron.Shared.Helpers;

namespace MSMDMPatron
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MSMDMPatron", Version = "v1" });
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

            services.AddDbContext<MDMPatronDBContext>(options =>
             options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPatronRepository, PatronRepository>();
            services.AddScoped<IPatronService, PatronService>();
            services.AddScoped<IGamingPointsRepository, GamingPointsRepository>();
            services.AddScoped<IGamingPointsService, GamingPointsService>();
            services.AddScoped<IGamingKPISRepository, GamingKPISRepository>();
            services.AddScoped<IGamingKPISService, GamingKPISService>();
        
            services.AddMvc().AddMvcOptions(options =>
            {
              options.Filters.Add<LoggingActionFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MSMDMPatron v1"));
            // }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(_policyName);
            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
