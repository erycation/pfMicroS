using System.Collections.Generic;
using tsogosun.com.MSPatronDetails.Model.Dtos.IGTConfig;
using tsogosun.com.MSPatronDetails.Model.Dtos.IGTPatronDetails;

namespace tsogosun.com.MSPatronDetails.Repository.Interface
{
    public interface IIGTEnrolmentConfigRepository
    {
        IGTEnrolmentConfigDto GetEnrollmentConfigutaionBySiteId(int siteId);
        List<IGTEnrolmentConfigDto> GetAllEnrollmentConfigutaions();
    }
}
