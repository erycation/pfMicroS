using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using tsogosun.com.MSPatronDetails.App_Start;
using tsogosun.com.MSPatronDetails.Repository;
using tsogosun.com.MSPatronDetails.Repository.Interface;
using tsogosun.com.MSPatronDetails.Service;
using tsogosun.com.MSPatronDetails.Service.Interface;
using tsogosun.com.MSPatronDetails.Shared;
using tsogosun.com.MSPatronDetails.Shared.Helpers;

namespace MSPatronDetails
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MSPatronDetails", Version = "v1" });
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

            services.AddDbContext<PatronDetailsDBContext>(options =>
             options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IGMSPatronDetailsRepository, GMSPatronDetailsRepository>();
            services.AddScoped<IGMSPatronDetailsService, GMSPatronDetailsService>();
            services.AddScoped<IPatronDetailsRepository, PatronDetailsRepository>();
            services.AddScoped<IPatronDetailsService, PatronDetailsService>();
            services.AddScoped<IPatronAddressRepository, PatronAddressRepository>();
            services.AddScoped<IPatronAddressService, PatronAddressService>();
            services.AddScoped<IIGTEnrolmentConfigRepository, IGTEnrolmentConfigRepository>();
            services.AddScoped<IIGTEnrolmentConfigService, IGTEnrolmentConfigService>();

            services.AddMvc().AddMvcOptions(options =>
            {
                options.Filters.Add<LoggingActionFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
           // {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MSPatronDetails v1"));
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
