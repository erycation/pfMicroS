using MSPatronRewardsAdmin.Model.Dtos;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Service.Interface
{
    public interface IPrizeTypeService
    {

        List<PrizeTypeDto> GetPrizeTypesBySiteId(int siteId);

    }
}
