
using tsogosun.com.MSPatronDetails.Model.Dtos;
using tsogosun.com.MSPatronDetails.Shared.Utils;

namespace tsogosun.com.MSPatronDetails.Repository.Interface
{
    public interface IGMSPatronDetailsRepository
    {
        GMSProfileReturnResult AddGMSPatronDetails(GMSPatronDetails gmsPatronDetails);
    }
}
