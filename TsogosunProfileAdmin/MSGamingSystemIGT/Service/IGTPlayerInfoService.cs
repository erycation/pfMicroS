
using System.Linq;
using tsogosun.com.GamingSystemIGT.Model.IGTPlayerFindInfoDto.Request;
using tsogosun.com.GamingSystemIGT.Model.IGTPlayerFindInfoDto.Response;
using tsogosun.com.GamingSystemIGT.Service.Interface;
using tsogosun.com.MSGamingSystemIGT.Model.Request;
using tsogosun.com.MSGamingSystemIGT.Service.Interface;
using tsogosun.com.MSGamingSystemIGT.Shared.Enum;

namespace tsogosun.com.MSGamingSystemIGT.Service
{
    public class IGTPlayerInfoService : IIGTPlayerInfoService
    {

        private readonly IAppSettingsConfigService _appSettingsConfigService;
        private readonly IPlayerInfoIGTService _playerFindInfoIGTService;

        public IGTPlayerInfoService(IAppSettingsConfigService appSettingsConfigService,
                                   IPlayerInfoIGTService playerFindInfoIGTService)
        {

            _appSettingsConfigService = appSettingsConfigService;
            _playerFindInfoIGTService = playerFindInfoIGTService;

        }

        public ResponseIGTPlayerInfo GetIGTPlayerInfoByName(RequestPlayerInfoByNameIGT requestPlayerInfoByNameIGT)
        {

            var ipAddress = _appSettingsConfigService.GetUnitsIpAddressConfig().
                                    Where(c => c.Site == requestPlayerInfoByNameIGT.SiteId.ToString() &&
                                            c.Interface.ToLower() == ADIInterfaceEnum.MobileCRMAppInterface.ToString().ToLower()).SingleOrDefault().IpAddress;

            var requestIGTPlayerInfoByName = new RequestIGTPlayerInfoByName
            {
                FirstName = requestPlayerInfoByNameIGT.FirstName,
                LastName = requestPlayerInfoByNameIGT.LastName,
                SiteID = requestPlayerInfoByNameIGT.SiteId.ToString(),
                IpAddress = ipAddress
            };

            return _playerFindInfoIGTService.GetIGTPlayerInfoByName(requestIGTPlayerInfoByName);
        }

        public ResponseIGTPlayerInfo GetIGTPlayerInfoByPlayerID(RequestPlayerInfoByPlayerIDIGT requestPlayerInfoByPlayerIDIGT)
        {

            var ipAddress = _appSettingsConfigService.GetUnitsIpAddressConfig().
                                    Where(c => c.Site == requestPlayerInfoByPlayerIDIGT.SiteId.ToString() &&
                                            c.Interface.ToLower() == ADIInterfaceEnum.MobileCRMAppInterface.ToString().ToLower()).SingleOrDefault().IpAddress;

            var requestIGTPlayerInfoByPlayerID = new RequestIGTPlayerInfoByPlayerID
            {
                PlayerID = requestPlayerInfoByPlayerIDIGT.PlayerID,
                SiteID = requestPlayerInfoByPlayerIDIGT.SiteId.ToString(),
                IpAddress = ipAddress
            };

            return _playerFindInfoIGTService.GetIGTPlayerInfoByPlayerID(requestIGTPlayerInfoByPlayerID);
        }

        public ResponseIGTPlayerInfo GetIGTPlayerInfoBySSN(RequestPlayerInfoBySSNIGT requestPlayerInfoBySSNIGT)
        {

            var ipAddress = _appSettingsConfigService.GetUnitsIpAddressConfig().
                                    Where(c => c.Site == requestPlayerInfoBySSNIGT.SiteId.ToString() &&
                                            c.Interface.ToLower() == ADIInterfaceEnum.MobileCRMAppInterface.ToString().ToLower()).SingleOrDefault().IpAddress;

            var requestIGTPlayerInfoBySSN = new RequestIGTPlayerInfoBySSN
            {
                SSN = requestPlayerInfoBySSNIGT.SSN,
                SiteID = requestPlayerInfoBySSNIGT.SiteId.ToString(),
                IpAddress = ipAddress
            };

            return _playerFindInfoIGTService.GetIGTPlayerInfoBySSN(requestIGTPlayerInfoBySSN);
        }
    }
}
