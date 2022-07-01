

using tsogosun.com.GamingSystemIGT.Model.IGTCountryInfoDto.Request;
using tsogosun.com.GamingSystemIGT.Model.IGTCountryInfoDto.Response;

namespace tsogosun.com.GamingSystemIGT.Service.Interface
{
    public interface ICountryInfoIGTService
    {
        ResponseIGTCountryInfo GetIGTCountryInfoName(RequestIGTCountryInfo requestIGTCountryInfo);
        ResponseIGTZipCode GetIGTZipCode(RequestIGTZipCode requestIGTZipCode);
    }
}
