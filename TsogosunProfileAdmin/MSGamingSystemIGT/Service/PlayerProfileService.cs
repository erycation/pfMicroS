

using System.Linq;
using tsogosun.com.GamingSystemIGT.Model.PlayerProfileDto;
using tsogosun.com.GamingSystemIGT.Model.Request;
using tsogosun.com.GamingSystemIGT.Service.Interface;
using tsogosun.com.MSGamingSystemIGT.Model.Request;
using tsogosun.com.MSGamingSystemIGT.Service.Interface;
using tsogosun.com.MSGamingSystemIGT.Shared.Enum;
using tsogosun.com.MSGamingSystemIGT.Shared.Helpers;

namespace tsogosun.com.MSGamingSystemIGT.Service
{
    public class PlayerProfileService : IPlayerProfileService
    {

        private readonly IAppSettingsConfigService _appSettingsConfigService;
        private readonly IPlayerProfileIGTService _playerProfileIGTService;

        public PlayerProfileService(IAppSettingsConfigService appSettingsConfigService,
                                    IPlayerProfileIGTService playerProfileIGTService)
        {

            _appSettingsConfigService = appSettingsConfigService;
            _playerProfileIGTService = playerProfileIGTService;

        }

        public ResponsePlayerProfile GetPlayerProfileByPatronNo(RequestPlayerProfile requestPlayerProfile)
        {

            var ipAddress = _appSettingsConfigService.GetUnitsIpAddressConfig().
                                    Where(c => c.Site.ToLower() == requestPlayerProfile.SiteId.ToString().ToLower() &&
                                            c.Interface.ToLower() == ADIInterfaceEnum.MobileCRMAppInterface.ToString().ToLower()).SingleOrDefault().IpAddress;

            var reqPlayerProfile = new RequestPlayerProfileIGT
            {
                PatronNo = requestPlayerProfile.PatronNo,
                SiteID = requestPlayerProfile.SiteId.ToString(),
                IpAddress = ipAddress
            };

            return _playerProfileIGTService.GetPlayerProfileByPatronNo(reqPlayerProfile);
        }

        public ResponsePlayerProfile AddPlayerProfile(RequestAddUpdatePlayerProfile requestAddUpdatePlayerProfile)
        {

            var ipAddress = _appSettingsConfigService.GetUnitsIpAddressConfig().
                                   Where(c => c.Site.ToLower() == requestAddUpdatePlayerProfile.SiteId.ToString().ToLower() &&
                                           c.Interface.ToLower() == ADIInterfaceEnum.MobileCRMAppInterface.ToString().ToLower()).SingleOrDefault().IpAddress;

            var reqAddUpdatePlayerProfile = new RequestAddUpdatePlayerProfileIGT
            {
                IpAddress = ipAddress,
                PlayerProfile = requestAddUpdatePlayerProfile.PlayerProfile
            };

            var responseAddUpdatePlayerProfileIGT = _playerProfileIGTService.AddUpdatePlayerProfile(reqAddUpdatePlayerProfile);

            if (responseAddUpdatePlayerProfileIGT.PlayerProfileBody.Error != null)
                throw new AppException(responseAddUpdatePlayerProfileIGT.PlayerProfileBody.Error.ErrorDescription);
            return responseAddUpdatePlayerProfileIGT;
        }

        public ResponsePlayerProfile UpdatePlayerProfile(RequestAddUpdatePlayerProfile requestAddUpdatePlayerProfile, string playerId)
        {

            var ipAddress = _appSettingsConfigService.GetUnitsIpAddressConfig().
                                   Where(c => c.Site.ToLower() == requestAddUpdatePlayerProfile.SiteId.ToString().ToLower() &&
                                           c.Interface.ToLower() == ADIInterfaceEnum.MobileCRMAppInterface.ToString().ToLower()).SingleOrDefault().IpAddress;

            var reqAddUpdatePlayerProfile = new RequestAddUpdatePlayerProfileIGT
            {
                IpAddress = ipAddress,
                PlayerProfile = requestAddUpdatePlayerProfile.PlayerProfile
            };

            var responseAddUpdatePlayerProfileIGT = _playerProfileIGTService.UpdatePlayerProfile(reqAddUpdatePlayerProfile, playerId);

            if (responseAddUpdatePlayerProfileIGT.PlayerProfileBody.Error != null)
                throw new AppException(responseAddUpdatePlayerProfileIGT.PlayerProfileBody.Error.ErrorDescription);
            return responseAddUpdatePlayerProfileIGT;
        }
    }
}
