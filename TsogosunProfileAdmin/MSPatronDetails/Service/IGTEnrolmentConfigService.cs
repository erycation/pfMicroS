using System.Collections.Generic;
using tsogosun.com.MSPatronDetails.Model.Dtos.IGTConfig;
using tsogosun.com.MSPatronDetails.Repository.Interface;
using tsogosun.com.MSPatronDetails.Service.Interface;

namespace tsogosun.com.MSPatronDetails.Service
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
    }
}
