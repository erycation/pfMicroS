

using tsogosun.com.MSMDMPatron.Shared.Paging;

namespace tsogosun.com.MSMDMPatron.Model.Request
{
    public class RequestPatronParameter : Parameters
    {
        public int? SiteID { set; get; }
        public long? PatronNumber { set; get; }
        public string IDPassport { set; get; }
        public string MobileNumber { set; get; }
        public string PatronName { set; get; }
        public string PatronSurname { set; get; }
        public string EmailAddress { set; get; }

    }
}