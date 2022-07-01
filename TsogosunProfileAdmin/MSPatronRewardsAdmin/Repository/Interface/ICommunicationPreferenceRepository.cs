using MSPatronRewardsAdmin.Model.Dtos;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Repository.Interface
{
    public interface ICommunicationPreferenceRepository
    {

        List<CommunicationPreferenceDto> GetAllCommunicationPreferencesBySiteId(string patronNo, int siteId);

    }
}
