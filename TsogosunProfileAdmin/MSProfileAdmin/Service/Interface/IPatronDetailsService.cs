
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos.PatronDetails;
using tsogosun.com.MSProfileAdmin.Model.Request;
using tsogosun.com.MSProfileAdmin.Shared.Utils;

namespace tsogosun.com.MSProfileAdmin.Service.Interface
{
    public interface IPatronDetailsService
    {
        List<PatronDetailsDto> GetPatronDetailsBySiteId(RequestPatronDetails requestPatronDetails);
        ReturnResult UpdatePatronDetailsStatus(RequestUpdatePatronStatus requestUpdatePatronStatus);
        PatronsDetailsInfoDto GetPatronDetailByUserId(int userId, int siteId);
        ReturnResult UpdatePatronDetails(PatronsDetailsInfoDto patronsDetailsInfoDto);
        ReturnResult UpdatePatronAddress(PatronsDetailsInfoDto patronsDetailsInfoDto);
        ConfirmedPatronDetailsDto GetConfirmedPatronDetailByUserId(long userId, int siteId);

    }
}
