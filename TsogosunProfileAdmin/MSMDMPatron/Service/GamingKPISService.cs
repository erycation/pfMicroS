using System.Collections.Generic;
using tsogosun.com.MSMDMPatron.Model.Dtos;
using tsogosun.com.MSMDMPatron.Model.Request;
using tsogosun.com.MSMDMPatron.Repository.Interface;
using tsogosun.com.MSMDMPatron.Service.Interface;
using tsogosun.com.MSMDMPatron.Shared.Helpers;
using tsogosun.com.MSMDMPatron.Shared.Utils;

namespace tsogosun.com.MSMDMPatron.Service
{
    public class GamingKPISService : IGamingKPISService
    {

        private readonly IGamingKPISRepository _gamingKPISRepository;

        public GamingKPISService(IGamingKPISRepository gamingKPISRepository)
        {
            _gamingKPISRepository = gamingKPISRepository;
        }

        public List<GamingKPISDeffinitionDto> GetGamingKPISDeffinition()
        {
            return _gamingKPISRepository.GetGamingKPISDeffinition();
        }

        public GamingKPISUnitDto GetGamingKPISByPatronId(RequestGamingKPISUnit requestGamingKPISUnit)
        {
            requestGamingKPISUnit.StartDate = DateUtil.StartOfDay(requestGamingKPISUnit.StartDate);
            requestGamingKPISUnit.EndDate = DateUtil.EndOfDay(requestGamingKPISUnit.EndDate);
            var gamingKpis = _gamingKPISRepository.GetGamingKPISByPatronId(requestGamingKPISUnit);
            if (gamingKpis == null) throw new AppException($"Patron No {requestGamingKPISUnit.PatronId}, Gaming KPIs not found between {requestGamingKPISUnit.StartDate:dd/MM/yyyy} and {requestGamingKPISUnit.EndDate:dd/MM/yyyy}");
            return gamingKpis;
        }

        public GamingKPISTSGDto GetGamingKPISByTsogosunId(RequestGamingKPISTSG requestGamingKPISTSG)
        {
            requestGamingKPISTSG.StartDate = DateUtil.StartOfDay(requestGamingKPISTSG.StartDate);
            requestGamingKPISTSG.EndDate = DateUtil.EndOfDay(requestGamingKPISTSG.EndDate);
            var gamingKpis = _gamingKPISRepository.GetGamingKPISByTsogosunId(requestGamingKPISTSG);
            if (gamingKpis == null) throw new AppException($"Gaming KPIs not found between {requestGamingKPISTSG.StartDate:dd/MM/yyyy} and {requestGamingKPISTSG.EndDate:dd/MM/yyyy}");
            return gamingKpis;
        }
    }
}
