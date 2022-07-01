

using System.Collections.Generic;
using tsogosun.com.MSMDMPatron.Model.Dtos;
using tsogosun.com.MSMDMPatron.Model.Request;

namespace tsogosun.com.MSMDMPatron.Repository.Interface
{
    public interface IGamingKPISRepository
    {
        List<GamingKPISDeffinitionDto> GetGamingKPISDeffinition();
        GamingKPISUnitDto GetGamingKPISByPatronId(RequestGamingKPISUnit requestGamingKPISUnit);
        GamingKPISTSGDto GetGamingKPISByTsogosunId(RequestGamingKPISTSG requestGamingKPISTSG);
    }
}
