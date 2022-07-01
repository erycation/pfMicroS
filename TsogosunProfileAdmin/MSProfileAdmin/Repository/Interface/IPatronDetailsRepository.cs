
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos.PatronDetails;
using tsogosun.com.MSProfileAdmin.Model.Request;
using tsogosun.com.MSProfileAdmin.Shared.Utils;

namespace tsogosun.com.MSProfileAdmin.Repository.Interface
{
    public interface IPatronDetailsRepository
    {
        List<PatronDetailsDto> GetPatronDetailsBySiteId(int siteId);
        ReturnResult UpdatePatronDetailsStatus(RequestUpdatePatronStatus requestUpdatePatronStatus);
        PatronsDetailsInfoDto GetPatronDetailByUserId(int userId);
        ReturnResult UpdatePatronDetails(PatronsDetailsInfoDto patronsDetailsInfoDto);
        ReturnResult UpdatePatronAddress(PatronsDetailsInfoDto patronsDetailsInfoDto);
        ConfirmedPatronDetailsDto GetConfirmedPatronDetailByUserId(long userId);
    }
}
