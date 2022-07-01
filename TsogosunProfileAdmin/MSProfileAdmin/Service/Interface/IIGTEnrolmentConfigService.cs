
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos;
using tsogosun.com.MSProfileAdmin.Model.Dtos.IGTConfig;
using tsogosun.com.MSProfileAdmin.Model.Dtos.IGTPatronDetails;

namespace tsogosun.com.MSProfileAdmin.Service.Interface
{
    public interface IIGTEnrolmentConfigService
    {
        IGTEnrolmentConfigDto GetEnrollmentConfigutaionBySiteId(int siteId);
        List<IGTEnrolmentConfigDto> GetAllEnrollmentConfigutaions();
        IGTCountryDto GetIGTCountryByName(int siteId, string countryName);

    }
}
