using System;
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos.Gamesmart;
using tsogosun.com.MSProfileAdmin.Model.Request;
using tsogosun.com.MSProfileAdmin.Repository.Interface;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Service
{
    public class GMAddressService : IGMAddressService
    {

        private readonly IGMAddressRepository _igmAddressRepository ;

        public GMAddressService(IGMAddressRepository igmAddressRepository)
        {
            _igmAddressRepository = igmAddressRepository;
        }

        public List<GMCountryDto> GetCountriesBySiteId(int siteId)
        {
            return _igmAddressRepository.GetCountriesBySiteId(siteId);
        }

        public List<GMProvinceDto> GetProvincesBySiteId(int siteId, int countryId)
        {
            return _igmAddressRepository.GetProvincesBySiteId(siteId, countryId);
        }

        public List<GMAddressDto> GetAddressByProvinceId(RequestGMAddress requestGMAddress)
        {
            return _igmAddressRepository.GetAddressByProvinceId(requestGMAddress);
        }
    }
}
