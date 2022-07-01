using System;

namespace tsogosun.com.MSMDMPatron.Model.Dtos
{
    public class GamingKPISDto
    {
		
		public DateTime? LastPlayDate { get; set; }
		public decimal Slots_Handle { get; set; }
		public decimal Slots_TheoWin { get; set; }
		public decimal Slots_ActualWin { get; set; }
		public decimal Tables_Drop { get; set; }
		public decimal Tables_TheoWin { get; set; }
		public decimal Tables_ActualWin { get; set; }
		public long Visits { get; set; }
		public decimal Total_TheoWin { get; set; }
		public decimal Total_ActualWin { get; set; }
		public decimal AvgSpend { get; set; }
		public decimal Slots_Worth { get; set; }
		public decimal Tables_Worth { get; set; }
		// [Column(TypeName = "decimal(18,4)")]
		public decimal Total_Worth { get; set; }
		public string VisitSegment { get; set; }
		public string SpendSegment { get; set; }

	}
}
