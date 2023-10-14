namespace HMS_Web_APIs.Models.RequestModel
{
    public class AppointmentBookSmsRequestModel
    {
        public int UserId { get; set; }
        public int SlotAvailabilityId { get; set; }
        public string ToPhoneNumber { get; set; }
        public string? Message { get; set; }
    }
}
