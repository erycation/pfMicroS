
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos.PatronDetails;
using tsogosun.com.MSProfileAdmin.Model.Request;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Service
{
    public class PatronAddressService : IPatronAddressService
    {

        private readonly IPatronAddressRepository _patronAddressRepository;

        public PatronAddressService(IPatronAddressRepository patronAddressRepository)
        {
            _patronAddressRepository = patronAddressRepository;
        }

        public List<PatronAddressSearchDto> GetPatronAddressSearch(RequestPatronAddress requestPatronAddress)
        {
            return _patronAddressRepository.GetPatronAddressSearch(requestPatronAddress);
        }
    }
}