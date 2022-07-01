using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tsogosun.com.GamingSystemIGT.Model.IGTCountryInfoDto.Request;
using tsogosun.com.GamingSystemIGT.Model.IGTCountryInfoDto.Response;
using tsogosun.com.GamingSystemIGT.Service.Interface;
using tsogosun.com.MSGamingSystemIGT.Model.Request;
using tsogosun.com.MSGamingSystemIGT.Service.Interface;
using tsogosun.com.MSGamingSystemIGT.Shared.Enum;

namespace tsogosun.com.MSGamingSystemIGT.Service
{
    public class CountryInfoService : ICountryInfoService
    {

        private readonly IAppSettingsConfigService _appSettingsConfigService;
        private readonly ICountryInfoIGTService _countryInfoIGTService;

        public CountryInfoService(IAppSettingsConfigService appSettingsConfigService,
                                   ICountryInfoIGTService countryInfoIGTService)
        {
            _appSettingsConfigService = appSettingsConfigService;
            _countryInfoIGTService = countryInfoIGTService;
        }

        public ResponseIGTCountryInfo GetCountryInfo(RequestCountryInfoByNameIGT requestCountryInfoByNameIGT)
        {

            var ipAddress = _appSettingsConfigService.GetUnitsIpAddressConfig().
                                    Where(c => c.Site == requestCountryInfoByNameIGT.SiteId.ToString() &&
                                            c.Interface.ToLower() == ADIInterfaceEnum.MobileCRMAppInterface.ToString().ToLower()).SingleOrDefault().IpAddress;

            var requestIGTCountryInfo = new RequestIGTCountryInfo
            {
                
                ConditionClause = requestCountryInfoByNameIGT.CountryName,
                ConditionValue = requestCountryInfoByNameIGT.CountryValue,
                SiteID = requestCountryInfoByNameIGT.SiteId.ToString(),
                IpAddress = ipAddress
            };

            return _countryInfoIGTService.GetIGTCountryInfoName(requestIGTCountryInfo);
        }
    
        public ResponseIGTZipCode GetZipCodeDetails(RequestZipCodeIGT requestZipCodeIGT)
        {
            var ipAddress = _appSettingsConfigService.GetUnitsIpAddressConfig().
                                   Where(c => c.Site == requestZipCodeIGT.SiteId.ToString() &&
                                           c.Interface.ToLower() == ADIInterfaceEnum.MobileCRMAppInterface.ToString().ToLower()).SingleOrDefault().IpAddress;

            var requestIGTZipCode = new RequestIGTZipCode
            {

                ConditionClause = requestZipCodeIGT.ZipCodeName,
                ConditionValue = requestZipCodeIGT.ZipCodeValue,
                SiteID = requestZipCodeIGT.SiteId.ToString(),
                IpAddress = ipAddress
            };

            return _countryInfoIGTService.GetIGTZipCode(requestIGTZipCode);

        }

    }
}
