
using System.Collections.Generic;
using tsogosun.com.MSPatronDetails.Model.Dtos;
using tsogosun.com.MSPatronDetails.Model.Request;
using tsogosun.com.MSPatronDetails.Shared.Utils;

namespace tsogosun.com.MSPatronDetails.Repository.Interface
{
    public interface IPatronDetailsRepository
    {
        List<PatronDetailsDto> GetPatronDetailsBySiteId(int siteId);
        ReturnResult UpdatePatronDetailsStatus(RequestUpdatePatronStatus requestUpdatePatronStatus);
        //to be removed
        PatronsDetailsInfoDto GetPatronDetailByUserId(int userId);
        UnconfirmedGMSPatronDetailsInfoDto GetUnconfirmedGMSPatronDetailsInfoByUserId(int userId);
        UnconfirmedIGTPatronDetailsInfoDto GetUnconfirmedIGTPatronDetailsInfoByUserId(int userId);
        ReturnResult UpdateUnconfirmedGMSPatronDetails(UnconfirmedGMSPatronDetailsInfoDto unconfirmedGMSPatronDetailsInfoDto);
        ReturnResult UpdateUnconfirmedIGTPatronDetails(UnconfirmedIGTPatronDetailsInfoDto unconfirmedIGTPatronDetailsInfoDto);

            //to be delel

        ReturnResult UpdatePatronDetails(PatronsDetailsInfoDto patronsDetailsInfoDto);
        ReturnResult UpdatePatronAddress(PatronsDetailsInfoDto patronsDetailsInfoDto);
        IGTConfirmedPatronDetailsDto GetConfirmedPatronDetailFromIGTByUserId(long userId);
        GMSConfirmedPatronDetailsDto GetConfirmedPatronDetailFromGamesmartByUserId(long userId);
        List<ApprovedUserDetailsDto> GetApprovedUserDetailsBySiteId(int siteId);
        ReturnResult ConfirmPlayerStatusAfterSubmitToGaming(ConfirmPlayerToSubmitGamingDto confirmPlayerToSubmitGamingDto);
    }
}
