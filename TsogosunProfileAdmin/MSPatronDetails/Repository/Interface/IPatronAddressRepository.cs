
using System.Collections.Generic;
using tsogosun.com.MSPatronDetails.Model.Dtos;
using tsogosun.com.MSPatronDetails.Model.Request;

namespace tsogosun.com.MSPatronDetails.Repository.Interface
{
    public interface IPatronAddressRepository
    {
        List<PatronAddressSearchDto> GetPatronAddressSearch(RequestPatronAddress requestPatronAddress);
    }
}
