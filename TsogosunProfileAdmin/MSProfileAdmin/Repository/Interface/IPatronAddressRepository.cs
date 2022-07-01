
using System.Collections.Generic;
using tsogosun.com.MSProfileAdmin.Model.Dtos.PatronDetails;
using tsogosun.com.MSProfileAdmin.Model.Request;

namespace tsogosun.com.MSProfileAdmin.Repository.Interface
{
    public interface IPatronAddressRepository
    {
        List<PatronAddressSearchDto> GetPatronAddressSearch(RequestPatronAddress requestPatronAddress);
    }
}
