

namespace tsogosun.com.MSPatronDetails.Model.Dtos
{
    public class PatronAddressSearchDto 
    {        
        public long PcId { get; set; }
        public long? CountryID { get; set; }
        public string Country { get; set; }
        public long? ProvID { get; set; }
        public string ProvDescription { get; set; }
        public string Town { get; set; }
        public string Area { get; set; }
        public string PostalCode { get; set; }
    }
}

