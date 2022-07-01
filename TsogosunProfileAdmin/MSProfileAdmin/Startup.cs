using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using tsogosun.com.MSProfileAdmin.App_Start;
using tsogosun.com.MSProfileAdmin.Model;
using tsogosun.com.MSProfileAdmin.Repository;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Service;
using tsogosun.com.MSProfileAdmin.Service.Interface;
using tsogosun.com.MSProfileAdmin.Shared;
using tsogosun.com.MSProfileAdmin.Shared.Helpers;

namespace MSProfileAdmin
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MSProfileAdmin", Version = "v1" });
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

            services.AddDbContext<ProfileAdminDBContext>(options =>
              options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(
                            Encoding.ASCII.GetBytes(Configuration.GetSection("JWTSettings:SecretKey").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.Configure<DomainConfig>(Configuration.GetSection("DomainConfig"));
            services.AddSingleton<IAuthManager>(new AuthManager(Configuration.GetSection("JWTSettings:SecretKey").Value));           
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IActiveDirectoryAuthService, ActiveDirectoryAuthService>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<ISiteRepository, SiteRepository>();
            services.AddScoped<ISiteService, SiteService>();        
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IDefaultPermissionGroupRepository, DefaultPermissionGroupRepository>();
            services.AddScoped<IDefaultPermissionGroupService, DefaultPermissionGroupService>();
            services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
            services.AddScoped<IUserPermissionService, UserPermissionService>();
            services.AddScoped<IPrizeTypeRepository, PrizeTypeRepository>();
            services.AddScoped<IPrizeTypeService, PrizeTypeService>();
            services.AddScoped<IScratchCardStrapiService, ScratchCardStrapiService>();
            services.AddScoped<ILeaderBoardStrapiService, LeaderBoardStrapiService>();
            services.AddScoped<IAuditLogsService, AuditLogsService>();
            services.AddScoped<IPatronDetailsRepository, PatronDetailsRepository>();
            services.AddScoped<IPatronDetailsService, PatronDetailsService>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IPatronAddressRepository, PatronAddressRepository>();
            services.AddScoped<IPatronAddressService, PatronAddressService>();
            services.AddScoped<IIGTEnrolmentConfigRepository, IGTEnrolmentConfigRepository>();
            services.AddScoped<IIGTEnrolmentConfigService, IGTEnrolmentConfigService>();
            services.AddScoped<IGMAddressRepository, GMAddressRepository>();
            services.AddScoped<IGMAddressService, GMAddressService>();
            services.AddScoped<IGMDocumentTypeRepository, GMDocumentTypeRepository>();
            services.AddScoped<IGMDocumentTypeService, GMDocumentTypeService>();


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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MSProfileAdmin v1"));
            //}


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(_policyName);

            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            // custom jwt auth middleware
           // app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
