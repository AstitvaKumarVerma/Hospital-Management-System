using System.ComponentModel;

namespace HMS_Web_APIs.Models.RequestModel
{
    public class DoctorAvailabilityRequestDto
    {
        public int ProviderId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [DefaultValue("00:00:00")]
        public string StartTime { get; set; }
        [DefaultValue("00:00:00")]
        public string EndTime { get; set; } 
        public int IntervalMinutes { get; set; }
        
    }
}
