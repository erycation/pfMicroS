

using tsogosun.com.MSGamingSystemIGT.Shared;

namespace tsogosun.com.MSGamingSystemIGT.Model.Request
{
    public class RequestZipCodeIGT : HasSiteId
    {
        public string ZipCodeName { set; get; }
        public string ZipCodeValue { set; get; }
    }
}
