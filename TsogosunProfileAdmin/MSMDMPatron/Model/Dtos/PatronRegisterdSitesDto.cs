namespace tsogosun.com.MSMDMPatron.Model.Dtos
{
    public class PatronRegisterdSitesDto
    {
        public int NumberOfRegisteredSite { get; set; }
        public string RegisteredSiteValue
        {
            get
            {
                return NumberOfRegisteredSite > 0 ? "Yes": "No";
            }
        }
    }
}
