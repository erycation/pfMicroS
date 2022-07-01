

using tsogosun.com.MSProfileAdmin.Shared.Paging;

namespace tsogosun.com.MSProfileAdmin.Model.Request
{
    public class RequestPatronParameter : Parameters
    {
        public int? SiteID { set; get; }
        public int? PatronNumber { set; get; }
        public string IDPassport { set; get; }
        public string MobileNumber { set; get; }
        public string PatronName { set; get; }
        public string PatronSurname { set; get; }
        public string EmailAddress { set; get; }

    }
}
