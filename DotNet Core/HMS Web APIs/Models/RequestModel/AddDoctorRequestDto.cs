namespace HMS_Web_APIs.Models.RequestModel
{
    public class AddDoctorRequestDto
    {
        public string DoctorName { get; set; } = null!;
        public string DoctorPhone { get; set; } = null!;
        public DateTime DoctorDob { get; set; }
        public string DoctorEmail { get; set; } = null!;
        public string DoctorPassword { get; set; } = null!;
        public string Gender { get; set; } = null!;
    }
}
