
using System.Collections.Generic;
using System.Linq;
using tsogosun.com.MSPatronDetails.Model.Dtos;
using tsogosun.com.MSPatronDetails.Model.Request;
using tsogosun.com.MSPatronDetails.Repository.Interface;
using tsogosun.com.MSPatronDetails.Service.Interface;
using tsogosun.com.MSPatronDetails.Shared.Helpers;
using tsogosun.com.MSPatronDetails.Shared.Utils;

namespace tsogosun.com.MSPatronDetails.Service
{
    public class PatronDetailsService : IPatronDetailsService
    {

        private readonly IPatronDetailsRepository _patronDetailsRepository;
        private readonly IIGTEnrolmentConfigService _iGTEnrolmentConfigService;

        public PatronDetailsService(IPatronDetailsRepository patronDetailsRepository,
                                    IIGTEnrolmentConfigService iGTEnrolmentConfigService)
        {

            _patronDetailsRepository = patronDetailsRepository;
            _iGTEnrolmentConfigService = iGTEnrolmentConfigService;
        }

        public List<PatronDetailsDto> GetPatronDetailsBySiteId(RequestPatronDetails requestPatronDetails)
        {
            var patronDetails = _patronDetailsRepository.GetPatronDetailsBySiteId(requestPatronDetails.SiteId);
            if ((!string.IsNullOrEmpty(requestPatronDetails.Idpassport)) && (!string.IsNullOrEmpty(requestPatronDetails.MobileNumber)))
            {
                patronDetails = patronDetails.Where(p => p.IdpassportNO == requestPatronDetails.Idpassport || p.MobileNumber == requestPatronDetails.MobileNumber).ToList();
            }
            if ((!string.IsNullOrEmpty(requestPatronDetails.Idpassport)) && (string.IsNullOrEmpty(requestPatronDetails.MobileNumber)))
            {
                patronDetails = patronDetails.Where(p => p.IdpassportNO == requestPatronDetails.Idpassport).ToList();
            }
            if ((string.IsNullOrEmpty(requestPatronDetails.Idpassport)) && (!string.IsNullOrEmpty(requestPatronDetails.MobileNumber)))
            {
                patronDetails = patronDetails.Where(p => p.MobileNumber == requestPatronDetails.MobileNumber).ToList();
            }

            return patronDetails;
        }

        public ReturnResult UpdatePatronDetailsStatus(RequestUpdatePatronStatus requestUpdatePatronStatus)
        {
            var responsePatronDetails = _patronDetailsRepository.UpdatePatronDetailsStatus(requestUpdatePatronStatus);
            if (responsePatronDetails.ReturnCode == 1)
                throw new AppException(responsePatronDetails.ReturnMessage);
            return responsePatronDetails;
        }

        //to be removed
        public PatronsDetailsInfoDto GetPatronDetailByUserId(int userId, int siteId)
        {
            return _patronDetailsRepository.GetPatronDetailByUserId(userId); 
        }

        public UnconfirmedGMSPatronDetailsInfoDto GetUnconfirmedGMSPatronDetailsInfoByUserId(int userId)
        {
            return _patronDetailsRepository.GetUnconfirmedGMSPatronDetailsInfoByUserId(userId);
        }

        public UnconfirmedIGTPatronDetailsInfoDto GetUnconfirmedIGTPatronDetailsInfoByUserId(int userId)
        {
            return _patronDetailsRepository.GetUnconfirmedIGTPatronDetailsInfoByUserId(userId);
        }
        public ReturnResult UpdateUnconfirmedGMSPatronDetails(UnconfirmedGMSPatronDetailsInfoDto unconfirmedGMSPatronDetailsInfoDto)
        {
            var responsePatronDetails = _patronDetailsRepository.UpdateUnconfirmedGMSPatronDetails(unconfirmedGMSPatronDetailsInfoDto);
            if (responsePatronDetails.ReturnCode == 1)
                throw new AppException(responsePatronDetails.ReturnMessage);
            return responsePatronDetails;
        }

        public ReturnResult UpdateUnconfirmedIGTPatronDetails(UnconfirmedIGTPatronDetailsInfoDto unconfirmedIGTPatronDetailsInfoDto)
        {
            var responsePatronDetails = _patronDetailsRepository.UpdateUnconfirmedIGTPatronDetails(unconfirmedIGTPatronDetailsInfoDto);
            if (responsePatronDetails.ReturnCode == 1)
                throw new AppException(responsePatronDetails.ReturnMessage);
            return responsePatronDetails;
        }







        public ReturnResult UpdatePatronDetails(PatronsDetailsInfoDto patronsDetailsInfoDto)
        {
            var responsePatronDetails = _patronDetailsRepository.UpdatePatronDetails(patronsDetailsInfoDto);
            if (responsePatronDetails.ReturnCode == 1)
                throw new AppException(responsePatronDetails.ReturnMessage);
            return responsePatronDetails;
        }

        public ReturnResult UpdatePatronAddress(PatronsDetailsInfoDto patronsDetailsInfoDto)
        {
            var responsePatronDetails = _patronDetailsRepository.UpdatePatronAddress(patronsDetailsInfoDto);
            if (responsePatronDetails.ReturnCode == 1)
                throw new AppException(responsePatronDetails.ReturnMessage);
            return responsePatronDetails;
        }

        public IGTConfirmedPatronDetailsDto GetConfirmedPatronDetailFromIGTByUserId(long userId)
        {
            return _patronDetailsRepository.GetConfirmedPatronDetailFromIGTByUserId(userId);
        }

        public GMSConfirmedPatronDetailsDto GetConfirmedPatronDetailFromGamesmartByUserId(long userId, int siteId)
        {
            return _patronDetailsRepository.GetConfirmedPatronDetailFromGamesmartByUserId(userId);
        }
        public List<ApprovedUserDetailsDto> GetApprovedUserDetailsBySiteId(int siteId)
        {
            return _patronDetailsRepository.GetApprovedUserDetailsBySiteId(siteId);
        }
        public ReturnResult ConfirmPlayerStatusAfterSubmitToGaming(ConfirmPlayerToSubmitGamingDto confirmPlayerToSubmitGamingDto)
        {
            var responseConfirmPlayerStatus = _patronDetailsRepository.ConfirmPlayerStatusAfterSubmitToGaming(confirmPlayerToSubmitGamingDto);
            if (responseConfirmPlayerStatus.ReturnCode == 1)
                throw new AppException($"{responseConfirmPlayerStatus.ReturnMessage}");
            return responseConfirmPlayerStatus;
        }
    }
}
