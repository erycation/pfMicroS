
using System.Collections.Generic;
using tsogosun.com.MSPatronDetails.Model.Dtos;
using tsogosun.com.MSPatronDetails.Model.Request;

namespace tsogosun.com.MSPatronDetails.Service.Interface
{
    public interface IPatronAddressService
    {
        List<PatronAddressSearchDto> GetPatronAddressSearch(RequestPatronAddress requestPatronAddress);
    }
}
