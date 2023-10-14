namespace HMS_Web_APIs.Models.RequestModel
{
    public class AddPatientRequestDto
    {
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
    }
}
