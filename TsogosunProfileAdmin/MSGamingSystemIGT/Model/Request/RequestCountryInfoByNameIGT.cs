

using tsogosun.com.MSGamingSystemIGT.Shared;

namespace tsogosun.com.MSGamingSystemIGT.Model.Request
{
    public class RequestCountryInfoByNameIGT : HasSiteId
    {
        public string CountryName { set; get; }
        public string CountryValue { set; get; }
    }
}
