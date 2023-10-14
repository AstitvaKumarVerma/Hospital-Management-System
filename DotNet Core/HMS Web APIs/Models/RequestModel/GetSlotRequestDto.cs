namespace HMS_Web_APIs.Models.RequestModel
{
    public class GetSlotRequestDto
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int AvailabilityId { get; set; }
        public DateTime? DateAvailable { get; set; }
        public TimeSpan? TimeSlot { get; set; }

    }
}
