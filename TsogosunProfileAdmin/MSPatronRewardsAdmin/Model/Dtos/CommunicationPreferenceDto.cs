

namespace MSPatronRewardsAdmin.Model.Dtos
{
    public class CommunicationPreferenceDto
    {
        public string MessageCategory { get; set; }
        public bool Enabled { get; set; }
        public string Status
        {
            get
            {
                return Enabled == true ? "Yes" : "No";
            }
        }
    }
}
