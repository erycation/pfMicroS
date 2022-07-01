
namespace tsogosun.com.MSProfileAdmin.Model.Request
{
    public class RequestGMAddress
    {
        public int SiteId { get; set; }
        public int ProvinceId { get; set; }
        public string Town { get; set; }
        public string Suburb { get; set; }
        public string PostalCode { get; set; }
    }
}
