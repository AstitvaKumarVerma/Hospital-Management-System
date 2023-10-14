namespace HMS_Web_APIs.Models.RequestModel
{
    public class GetAllPatientRequestDto
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; } = null!;
        public DateTime PatientDob { get; set; }
        public string PatientPhone { get; set; } = null!;
        public string PatientEmail { get; set; } = null!;
        public string PatientPassword { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string FatherName { get; set; } = null!;
        public string MaritalStatus { get; set; } = null!;
        public string? BloodGroup { get; set; }
        public string? Symptoms { get; set; }
        public string? Diagnosis { get; set; }
        public int? DoctorId { get; set; }
        public string? DoctorName { get; set; } = null!;
        public DateTime AppointmentDate { get; set; }
        public TimeSpan? AppointmentTime { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
    }
}
