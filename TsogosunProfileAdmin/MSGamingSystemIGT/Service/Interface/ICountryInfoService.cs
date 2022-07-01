using tsogosun.com.GamingSystemIGT.Model.IGTCountryInfoDto.Response;
using tsogosun.com.MSGamingSystemIGT.Model.Request;

namespace tsogosun.com.MSGamingSystemIGT.Service.Interface
{
    public interface ICountryInfoService
    {
        ResponseIGTCountryInfo GetCountryInfo(RequestCountryInfoByNameIGT requestCountryInfoByNameIGT);
        ResponseIGTZipCode GetZipCodeDetails(RequestZipCodeIGT requestZipCodeIGT);
    }
}
