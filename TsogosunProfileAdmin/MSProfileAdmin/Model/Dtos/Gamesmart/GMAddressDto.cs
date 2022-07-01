namespace tsogosun.com.MSProfileAdmin.Model.Dtos.Gamesmart
{
    public class GMAddressDto
    {
        public int SiteId { get; set; }
        public int PostalCodeId { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string Town { get; set; }
        public string Suburb { get; set; }
        public string PostalCode { get; set; }
        public int? ProvinceId { get; set; }
    }
}
