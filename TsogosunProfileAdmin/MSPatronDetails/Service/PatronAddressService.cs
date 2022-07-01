
using System.Collections.Generic;
using tsogosun.com.MSPatronDetails.Model.Dtos;
using tsogosun.com.MSPatronDetails.Model.Request;
using tsogosun.com.MSPatronDetails.Repository.Interface;
using tsogosun.com.MSPatronDetails.Service.Interface;

namespace tsogosun.com.MSPatronDetails.Service
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