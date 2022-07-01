
namespace tsogosun.com.MSMDMPatron.Model.Dtos
{
    public class GamingPointsUnitDto
    {
		public short Property_Registered { get; set; }
		public string SiteFullName { get; set; }
		public int Patron_ID { get; set; }
		public int SlotPointsEarned { get; set; }
		public int TablePointsEarned { get; set; }
		public int TotalPointsEarned { get; set; }		
		public decimal SlotPointsBalance { get; set; }
		public decimal TablePointsBalance { get; set; }
		public decimal TotalPointsBalance { get; set; }		
		public string FootNote_Line1 { get; set; }
		public string FootNote_Line2 { get; set; }
	}
}


