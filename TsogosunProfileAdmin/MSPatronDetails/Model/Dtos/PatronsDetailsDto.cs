

using System;
using tsogosun.com.MSPatronDetails.Model.Dtos.PatronInfoDetails;

namespace tsogosun.com.MSPatronDetails.Model.Dtos
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

