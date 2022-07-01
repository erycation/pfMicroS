using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;

namespace GWProfileAdmin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //         .ConfigureAppConfiguration((hostBuilderContext, configurationBinder) =>
        //         {
        //             configurationBinder.AddJsonFile("configuration.json", false, true);
        //         })
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });


        public static IHostBuilder CreateHostBuilder(string[] args) =>
              Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder
                       .ConfigureAppConfiguration((hostingContext, config) =>
                       {
                           config
                               .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                           .AddOcelot("ConfigRoutes", hostingContext.HostingEnvironment)
                           .AddEnvironmentVariables();

                       });

                     webBuilder.UseStartup<Startup>();
                 });
    }
}
