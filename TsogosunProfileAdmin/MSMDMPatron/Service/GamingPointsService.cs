
using tsogosun.com.MSMDMPatron.Model.Dtos;
using tsogosun.com.MSMDMPatron.Repository.Interface;
using tsogosun.com.MSMDMPatron.Service.Interface;
using tsogosun.com.MSMDMPatron.Shared.Helpers;

namespace tsogosun.com.MSMDMPatron.Service
{
    public class GamingPointsService : IGamingPointsService
    {

        private readonly IGamingPointsRepository _gamingPointsRepository;

        public GamingPointsService(IGamingPointsRepository gamingPointsRepository)
        {
            _gamingPointsRepository = gamingPointsRepository;
        }

        public GamingPointsTSGDto GetTSGGamingPointsByTsogosunId(long tsogosunID)
        {
            var tsgGamingPoints = _gamingPointsRepository.GetTSGGamingPointsByTsogosunId(tsogosunID);
            if (tsgGamingPoints == null) throw new AppException($"Points not found");
            return tsgGamingPoints;
        }

        public GamingPointsUnitDto GetUnitGamingPointsByTsogosunId(long siteId, long patronNumber)
        {
            var patronGamingPoints = _gamingPointsRepository.GetUnitGamingPointsByTsogosunId(siteId, patronNumber);
            if (patronGamingPoints == null) throw new AppException($"Patron No {patronNumber}, Points not found");
            return patronGamingPoints;
        }
    }
}
