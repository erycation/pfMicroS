using MSPatronRewardsAdmin.Model.Dtos;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Repository.Interface
{
    public interface IPrizeTypeRepository
    {

        List<PrizeTypeDto> GetPrizeTypesBySiteId(int siteId);

    }
}
