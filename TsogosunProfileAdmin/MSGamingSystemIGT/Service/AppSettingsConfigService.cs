

using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using tsogosun.com.MSGamingSystemIGT.Model;
using tsogosun.com.MSGamingSystemIGT.Service.Interface;

namespace tsogosun.com.MSGamingSystemIGT.Service
{
    public class AppSettingsConfigService : IAppSettingsConfigService
    {

        private readonly IConfiguration _configuration;

        public AppSettingsConfigService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<UnitsIpAddressConfig> GetUnitsIpAddressConfig()
        {
            var unitsIpAddressConfig  = new List<UnitsIpAddressConfig>();

            var unitsIpConfigurations = _configuration.GetSection("UnitsIpAddressConfig").Get<UnitsIpAddressConfig[]>();

            foreach(var config in unitsIpConfigurations)
            {
                unitsIpAddressConfig.Add(new UnitsIpAddressConfig { Site = config.Site, Unit = config.Unit, Interface = config.Interface, IpAddress = config.IpAddress });
            }

            return unitsIpAddressConfig;
        }
    }
}

