
namespace MSPatronRewardsAdmin.Model.Dtos
{
    public class ScratchCardMessageDto
    {
        public int MessageId { get; set; }
        public string MessageToDisplay { get; set; }
        public bool IsActive { get; set; }
        public string Status
        {
            get
            {
                return IsActive == true ? "Active" : "Not Active";
            }
        }
    }
}

