
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos.PatronDetails;
using tsogosun.com.MSProfileAdmin.Model.Request;

namespace tsogosun.com.MSProfileAdmin.Service.Interface
{
    public interface IPatronAddressService
    {
        List<PatronAddressSearchDto> GetPatronAddressSearch(RequestPatronAddress requestPatronAddress);
    }
}
