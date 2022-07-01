using tsogosun.com.MSPatronDetails.Model.Dtos;
using tsogosun.com.MSPatronDetails.Repository.Interface;
using tsogosun.com.MSPatronDetails.Service.Interface;
using tsogosun.com.MSPatronDetails.Shared.Helpers;
using tsogosun.com.MSPatronDetails.Shared.Utils;

namespace tsogosun.com.MSPatronDetails.Service
{
    public class GMSPatronDetailsService : IGMSPatronDetailsService
    {

        private readonly IGMSPatronDetailsRepository _gmsPatronDetailsRepository;

        public GMSPatronDetailsService(IGMSPatronDetailsRepository gmsPatronDetailsRepository)
        {
            _gmsPatronDetailsRepository = gmsPatronDetailsRepository;
        }

        public GMSProfileReturnResult AddGMSPatronDetails(GMSPatronDetails gmsPatronDetails)
        {
            var responsePatron = _gmsPatronDetailsRepository.AddGMSPatronDetails(gmsPatronDetails);
            if (responsePatron.CustID == 0)
                throw new AppException($"{responsePatron.ReturnMessage}");
            return responsePatron;
        }
    }
}
