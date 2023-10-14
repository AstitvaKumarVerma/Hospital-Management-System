using System;
using System.Collections.Generic;

namespace HMS_Web_APIs.Models
{
    public partial class HmsProviderAvailabilityTable
    {
        public int Id { get; set; }
        public DateTime DateAvailable { get; set; }
        public TimeSpan TimeSlots { get; set; }
        public int? BookedBy { get; set; }
        public int? ProviderId { get; set; }
        public bool? IsBooked { get; set; }

        public virtual HmsPatientsTable? BookedByNavigation { get; set; }
        public virtual HmsDoctorsTable? Provider { get; set; }
    }
}
