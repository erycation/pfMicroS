

using MSPatronRewardsAdmin.Model.Dtos;
using MSPatronRewardsAdmin.Repository.Interface;
using MSPatronRewardsAdmin.Service.Interface;
using System.Collections.Generic;

namespace MSPatronRewardsAdmin.Service
{
    public class CommunicationPreferenceService : ICommunicationPreferenceService
    {

        private readonly ICommunicationPreferenceRepository _communicationPreferenceRepository;

        public CommunicationPreferenceService(ICommunicationPreferenceRepository communicationPreferenceRepository)
        {
            _communicationPreferenceRepository = communicationPreferenceRepository;
        }

        public List<CommunicationPreferenceDto> GetAllCommunicationPreferencesBySiteId(string patronNo, int siteId)
        {
            return _communicationPreferenceRepository.GetAllCommunicationPreferencesBySiteId(patronNo, siteId);
        }
    }
}
