using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos.IGTConfig;
using tsogosun.com.MSProfileAdmin.Model.Dtos.IGTPatronDetails;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Service
{
    public class IGTEnrolmentConfigService : IIGTEnrolmentConfigService
    {

        private readonly IIGTEnrolmentConfigRepository _iGTEnrolmentConfigRepository;

        public IGTEnrolmentConfigService(IIGTEnrolmentConfigRepository iGTEnrolmentConfigRepository)
        {
            _iGTEnrolmentConfigRepository = iGTEnrolmentConfigRepository;
        }

        public List<IGTEnrolmentConfigDto> GetAllEnrollmentConfigutaions()
        {
            return _iGTEnrolmentConfigRepository.GetAllEnrollmentConfigutaions();
        }

        public IGTEnrolmentConfigDto GetEnrollmentConfigutaionBySiteId(int siteId)
        {
            return _iGTEnrolmentConfigRepository.GetEnrollmentConfigutaionBySiteId(siteId);
        }

        public IGTCountryDto GetIGTCountryByName(int siteId, string countryName)
        {
            return _iGTEnrolmentConfigRepository.GetIGTCountryByName(siteId, countryName);
        }
    }
}
