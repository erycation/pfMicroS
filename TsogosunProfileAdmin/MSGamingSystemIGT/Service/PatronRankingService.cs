
using System.Linq;
using tsogosun.com.GamingSystemIGT.Model.PlayerRankingDto;
using tsogosun.com.GamingSystemIGT.Service.Interface;
using tsogosun.com.MSGamingSystemIGT.Model.Request;
using tsogosun.com.MSGamingSystemIGT.Service.Interface;
using tsogosun.com.MSGamingSystemIGT.Shared.Enum;
using tsogosun.com.MSGamingSystemIGT.Shared.Helpers;

namespace tsogosun.com.MSGamingSystemIGT.Service
{
    public class PatronRankingService : IPatronRankingService
    {

        private readonly IAppSettingsConfigService _appSettingsConfigService;
        private readonly IPatronRankingIGTService _patronRankingIGTService;

        public PatronRankingService(IAppSettingsConfigService appSettingsConfigService,
                                    IPatronRankingIGTService patronRankingIGTService)
        {

            _appSettingsConfigService = appSettingsConfigService;
            _patronRankingIGTService = patronRankingIGTService;

        }

        public ResponsePlayerRanking UpdatePlayerRanking(RequestPlayerRanking requestPlayerRanking)
        {

            var ipAddress = _appSettingsConfigService.GetUnitsIpAddressConfig().
                                       Where(c => c.Site == requestPlayerRanking.SiteId.ToString() &&
                                               c.Interface.ToLower() == ADIInterfaceEnum.MobileCRMAppInterface.ToString().ToLower()).SingleOrDefault().IpAddress;

            var requestPlayerRankingIGT = new RequestPlayerRankingIGT
            {
                IpAddress = ipAddress,
                PlayerID = requestPlayerRanking.PlayerID,
                SiteID = requestPlayerRanking.SiteId.ToString(),
                SiteDescription = requestPlayerRanking.SiteDescription,
                RankingID = requestPlayerRanking.RankingID,
                RankingDescription = requestPlayerRanking.RankingDescription
            };

            var responsePatronRanking = _patronRankingIGTService.UpdatePlayerRanking(requestPlayerRankingIGT);
            if(!responsePatronRanking.Success)
                throw new AppException(responsePatronRanking.ErrorDescription);
            return responsePatronRanking;
        }
    }
}
