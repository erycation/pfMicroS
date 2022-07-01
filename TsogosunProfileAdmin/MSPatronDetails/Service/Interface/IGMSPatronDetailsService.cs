
using tsogosun.com.MSPatronDetails.Model.Dtos;
using tsogosun.com.MSPatronDetails.Shared.Utils;

namespace tsogosun.com.MSPatronDetails.Service.Interface
{
    public interface IGMSPatronDetailsService
    {
        GMSProfileReturnResult AddGMSPatronDetails(GMSPatronDetails gmsPatronDetails);
    }
}
