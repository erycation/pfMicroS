using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MSPatronRewardsAdmin.App_Start;
using MSPatronRewardsAdmin.Repository;
using MSPatronRewardsAdmin.Repository.Interface;
using MSPatronRewardsAdmin.Service;
using MSPatronRewardsAdmin.Service.Interface;
using MSPatronRewardsAdmin.Shared;
using MSPatronRewardsAdmin.Shared.Helpers;

namespace MSPatronRewardsAdmin
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MSPatronRewardsAdmin", Version = "v1" });
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

            services.AddDbContext<PatronRewardsAdminDBContext>(options =>
              options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IScratchCardRepository, ScratchCardRepository>();
            services.AddScoped<IScratchCardService, ScratchCardService>();
            services.AddScoped<IScratchCardMessageRepository, ScratchCardMessageRepository>();
            services.AddScoped<IScratchCardMessageService, ScratchCardMessageService>();
            services.AddScoped<IScratchCardPrizeRepository, ScratchCardPrizeRepository>();
            services.AddScoped<IScratchCardPrizeService, ScratchCardPrizeService>();
            services.AddScoped<IScratchCardActiveTimesRepository, ScratchCardActiveTimesRepository>();
            services.AddScoped<IScratchCardActiveTimesService, ScratchCardActiveTimesService>();
            services.AddScoped<ILeaderBoardRepository, LeaderBoardRepository>();
            services.AddScoped<ILeaderBoardService, LeaderBoardService>();
            services.AddScoped<IMobileSettingRepository, MobileSettingRepository>();
            services.AddScoped<IMobileSettingService, MobileSettingService>();
            services.AddScoped<IGamingAreaRepository, GamingAreaRepository>();
            services.AddScoped<IGamingAreaService, GamingAreaService>();
            services.AddScoped<ICommunicationPreferenceRepository, CommunicationPreferenceRepository>();
            services.AddScoped<ICommunicationPreferenceService, CommunicationPreferenceService>();
            services.AddScoped<IPrizeTypeRepository, PrizeTypeRepository>();
            services.AddScoped<IPrizeTypeService, PrizeTypeService>();
         
            services.AddMvc()
           .AddMvcOptions(options =>
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MSPatronRewardsAdmin v1"));
            //}

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

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
