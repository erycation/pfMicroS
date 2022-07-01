using System;

namespace MSPatronRewardsAdmin.Model.Dtos
{
    public class ScratchCardActiveTimesDto
    {
        public long ScratchCardReleaseID { get; set; }
        public Guid ScratchCardUID { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime Dateinserted { get; set; } = DateTime.Now;
        public bool isActive { get; set; } = true;
        public string Status
        {
            get
            {
                return isActive == true ? "Active" : "Not Active";
            }
        }
        public string StartTime
        {
            get
            {
                return StartDateTime.ToString("HH:mm");
            }
        }
        public string EndTime
        {
            get
            {
                return EndDateTime.ToString("HH:mm");
            }
        }
    }
}
