using System.Collections.Generic;
using System.Linq;
using tsogosun.com.MSProfileAdmin.Model.Dtos.PatronDetails;
using tsogosun.com.MSProfileAdmin.Model.Request;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Service.Interface;
using tsogosun.com.MSProfileAdmin.Shared.Helpers;
using tsogosun.com.MSProfileAdmin.Shared.Utils;

namespace tsogosun.com.MSProfileAdmin.Service
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

        public PatronsDetailsInfoDto GetPatronDetailByUserId(int userId, int siteId)
        {
            var enrolmentConfigDto = _iGTEnrolmentConfigService.GetEnrollmentConfigutaionBySiteId(siteId);
            PatronsDetailsInfoDto patronsDetailsInfoDto = _patronDetailsRepository.GetPatronDetailByUserId(userId);
            patronsDetailsInfoDto.IGTEnrolmentConfig = enrolmentConfigDto ?? throw new AppException("IGT Enrollment users not configure, contact system administrator.");
            return patronsDetailsInfoDto;
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

        public ConfirmedPatronDetailsDto GetConfirmedPatronDetailByUserId(long userId, int siteId)
        {
            var enrolmentConfigDto = _iGTEnrolmentConfigService.GetEnrollmentConfigutaionBySiteId(siteId);
            if (enrolmentConfigDto == null)
                throw new AppException("IGT Enrollment users not configure, contact system administrator.");
            ConfirmedPatronDetailsDto confirmedPatronDetailsDto = _patronDetailsRepository.GetConfirmedPatronDetailByUserId(userId);
            if (confirmedPatronDetailsDto == null)
                throw new AppException("Verify patron details.");
            confirmedPatronDetailsDto.IGTEnrolmentConfig = enrolmentConfigDto;
            return confirmedPatronDetailsDto;
        }
    }
}
