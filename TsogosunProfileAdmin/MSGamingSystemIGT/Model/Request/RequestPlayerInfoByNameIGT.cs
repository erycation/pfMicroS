

using tsogosun.com.MSGamingSystemIGT.Shared;

namespace tsogosun.com.MSGamingSystemIGT.Model.Request
{
    public class RequestPlayerInfoByNameIGT : HasSiteId
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
    }
}
