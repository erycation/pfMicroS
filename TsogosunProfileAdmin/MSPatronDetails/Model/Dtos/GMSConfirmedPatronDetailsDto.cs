
using System;
using tsogosun.com.MSPatronDetails.Model.Dtos.ConfirmedPatron;

namespace tsogosun.com.MSPatronDetails.Model.Dtos
{
    public class GMSConfirmedPatronDetailsDto : ConfirmedPatronDetails
    {       
        public int CountryID { get; set; }
        public int ProvID { get; set; }
        public int PcId { get; set; }
        public int DocumentTypeId { get; set; }
        public DateTime? DocumentExpireDate { get; set; }
        public int? Pippep { get; set; }
        
    }
}
