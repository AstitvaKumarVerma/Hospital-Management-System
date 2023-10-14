using System.ComponentModel.DataAnnotations;

namespace HMS_Web_APIs.Models.RequestModel
{
    public class BookSlotRequestDto
    {
        [Required]
        public int AvailabilityId { get; set; }
        public bool? IsBooked { get; set; }
        public int? BookedBy { get; set; }
    }
}
