using System;

namespace tsogosun.com.MSProfileAdmin.Model.Request.Report
{
    public class RequestRedeemedReport
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SiteId { get; set; }
        public long PatronNo { get; set; }
    }
}
