
namespace tsogosun.com.MSMDMPatron.Model.Dtos
{
    public class GamingPointsTSGDto
    {
        public long? TsogosunID { get; set; }
        public decimal SlotPointsEarned { get; set; }
        public decimal TablePointsEarned { get; set; }
        public decimal TotalPointsEarned { get; set; }
        public int PointsToNextTier { get; set; }
        public decimal SlotPointsBalance { get; set; }
        public decimal TablePointsBalance { get; set; }
        public decimal? TotalPointsBalance { get; set; }
        public string FootNote_Line1 { get; set; }
        public string FootNote_Line2 { get; set; }
    }
}
