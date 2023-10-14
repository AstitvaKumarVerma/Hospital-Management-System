namespace HMS_Web_APIs.Models.RequestModel
{
    public class GetAllDoctorRequestDto
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = null!;
        public string DoctorPhone { get; set; } = null!;
        public DateTime DoctorDob { get; set; }
        public string DoctorEmail { get; set; } = null!;
        public string DoctorPassword { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
    }
}
