
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos.Gamesmart;
using tsogosun.com.MSProfileAdmin.Model.Request;

namespace tsogosun.com.MSProfileAdmin.Repository.Interface
{
    public interface IGMAddressRepository
    {
        List<GMCountryDto> GetCountriesBySiteId(int siteId);
        List<GMProvinceDto> GetProvincesBySiteId(int siteId, int countryId);
        List<GMAddressDto> GetAddressByProvinceId(RequestGMAddress requestGMAddress);
    }
}
