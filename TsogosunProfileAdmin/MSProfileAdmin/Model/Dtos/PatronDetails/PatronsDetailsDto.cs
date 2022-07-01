

using System;

namespace tsogosun.com.MSProfileAdmin.Model.Dtos.PatronDetails
{
    public class PatronDetailsDto : PatronDetailsInfo
    {        
        public int SiteId { get; set; }
        public string Status { get; set; }
        public string RecordStatus { get; set; }        
        public DateTime? CreatedDate { get; set; }
        public string AllocatedUser { get; set; }
        
    }
}

