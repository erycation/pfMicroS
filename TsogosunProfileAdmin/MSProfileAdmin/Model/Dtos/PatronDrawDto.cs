using System;

namespace tsogosun.com.MSProfileAdmin.Model.Dtos
{
    public class PatronDrawDto
    {
        public string PromotionName { get; set; }
        public DateTime? DrawDate { get; set; }
        public int? IngenicoTickets { get; set; }
        public int? FreeIssueTickets { get; set; }
        public int? FreeIssueBonusTickets { get; set; }
        public int? PointsTickets { get; set; }
        public int? PointsTransactionTickets { get; set; }
        public int? PointsToNextTicket { get; set; }
        public int? CollectableTickets { get; set; }
        public int? CollectedTickets { get; set; }
        public DateTime? DateCollected { get; set; }
        public string DisplayOn { get; set; }
        public string PromotionsStatus { get; set; }
        public string TicketStatus { get; set; }
       
    }
}
