

using MSPatronRewardsAdmin.Shared.Utils;

namespace MSPatronRewardsAdmin.Model.Response
{
    public class InsertPromotionResponse
    {
        public int PromotionID { get; set; }
        public int ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
    }
}
