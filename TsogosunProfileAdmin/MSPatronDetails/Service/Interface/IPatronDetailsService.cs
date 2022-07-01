
using System.Collections.Generic;
using tsogosun.com.MSPatronDetails.Model.Dtos;
using tsogosun.com.MSPatronDetails.Model.Request;
using tsogosun.com.MSPatronDetails.Shared.Utils;

namespace tsogosun.com.MSPatronDetails.Service.Interface
{
    public interface IPatronDetailsService
    {

        List<PatronDetailsDto> GetPatronDetailsBySiteId(RequestPatronDetails requestPatronDetails);
        ReturnResult UpdatePatronDetailsStatus(RequestUpdatePatronStatus requestUpdatePatronStatus);
        //to be removed
        PatronsDetailsInfoDto GetPatronDetailByUserId(int userId, int siteId);
        UnconfirmedGMSPatronDetailsInfoDto GetUnconfirmedGMSPatronDetailsInfoByUserId(int userId);
        UnconfirmedIGTPatronDetailsInfoDto GetUnconfirmedIGTPatronDetailsInfoByUserId(int userId);
        ReturnResult UpdateUnconfirmedGMSPatronDetails(UnconfirmedGMSPatronDetailsInfoDto unconfirmedGMSPatronDetailsInfoDto);
        ReturnResult UpdateUnconfirmedIGTPatronDetails(UnconfirmedIGTPatronDetailsInfoDto unconfirmedIGTPatronDetailsInfoDto);




            //to be deleted
        ReturnResult UpdatePatronDetails(PatronsDetailsInfoDto patronsDetailsInfoDto);
        ReturnResult UpdatePatronAddress(PatronsDetailsInfoDto patronsDetailsInfoDto);
        IGTConfirmedPatronDetailsDto GetConfirmedPatronDetailFromIGTByUserId(long userId);
        GMSConfirmedPatronDetailsDto GetConfirmedPatronDetailFromGamesmartByUserId(long userId, int siteId);        
        List<ApprovedUserDetailsDto> GetApprovedUserDetailsBySiteId(int siteId);
        ReturnResult ConfirmPlayerStatusAfterSubmitToGaming(ConfirmPlayerToSubmitGamingDto confirmPlayerToSubmitGamingDto);
    }
}
