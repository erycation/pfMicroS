using Microsoft.Extensions.DependencyInjection;
using tsogosun.com.GamingSystemIGT.Service;
using tsogosun.com.GamingSystemIGT.Service.Interface;
using tsogosun.com.GamingSystemIGT.XmlTransform;
using tsogosun.com.GamingSystemIGT.XmlTransform.Interface;

namespace tsogosun.com.GamingSystemIGT.Shared
{
    public static class IGTServiceCollectionExtensions
    {
        public static void AddIGTService(this IServiceCollection services)
        {         
           
            services.AddScoped<IPlayerProfileIGTService, PlayerProfileIGTService>();
            services.AddScoped<IPlayerProfileIGTXMLTransform, PlayerProfileIGTXMLTransform>();
            services.AddScoped<IPatronRankingIGTService, PatronRankingIGTService>();
            services.AddScoped<IPlayerInterestService, PlayerInterestService>();
            services.AddScoped<IPlayerInfoIGTService, PlayerInfoIGTService>();
            services.AddScoped<IPlayerInfoIGTXMLTransform, PlayerInfoIGTXMLTransform>();
        
            services.AddScoped<ICountryInfoIGTService, CountryInfoIGTService>();
            services.AddScoped<ICountryInfoIGTXMLTransform, CountryInfoIGTXMLTransform>();

        
            services.AddScoped<IADISoapServiceIGT, ADISoapServiceIGT>();
           

        }
    }
}
