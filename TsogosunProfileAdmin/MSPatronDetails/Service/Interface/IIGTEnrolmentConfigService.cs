
using System.Collections.Generic;
using tsogosun.com.MSPatronDetails.Model.Dtos;
using tsogosun.com.MSPatronDetails.Model.Dtos.IGTConfig;
using tsogosun.com.MSPatronDetails.Model.Dtos.IGTPatronDetails;

namespace tsogosun.com.MSPatronDetails.Service.Interface
{
    public interface IIGTEnrolmentConfigService
    {
        IGTEnrolmentConfigDto GetEnrollmentConfigutaionBySiteId(int siteId);
        List<IGTEnrolmentConfigDto> GetAllEnrollmentConfigutaions();
    }
}
