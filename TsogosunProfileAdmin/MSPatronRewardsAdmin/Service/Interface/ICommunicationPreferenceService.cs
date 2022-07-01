using MSPatronRewardsAdmin.Model.Dtos;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Service.Interface
{
    public interface ICommunicationPreferenceService
    {

        List<CommunicationPreferenceDto> GetAllCommunicationPreferencesBySiteId(string patronNo, int siteId);

    }
}
