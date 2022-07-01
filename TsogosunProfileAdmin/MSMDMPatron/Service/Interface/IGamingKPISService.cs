

using System.Collections.Generic;
using tsogosun.com.MSMDMPatron.Model.Dtos;
using tsogosun.com.MSMDMPatron.Model.Request;

namespace tsogosun.com.MSMDMPatron.Service.Interface
{
    public interface IGamingKPISService
    {
        List<GamingKPISDeffinitionDto> GetGamingKPISDeffinition();
        GamingKPISUnitDto GetGamingKPISByPatronId(RequestGamingKPISUnit requestGamingKPISUnit);
        GamingKPISTSGDto GetGamingKPISByTsogosunId(RequestGamingKPISTSG requestGamingKPISTSG);

    }
}
