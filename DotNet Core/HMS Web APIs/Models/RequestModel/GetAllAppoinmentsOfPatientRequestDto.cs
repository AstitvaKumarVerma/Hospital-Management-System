namespace HMS_Web_APIs.Models.RequestModel
{
    public class GetAllAppoinmentsOfPatientRequestDto
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppoinmentDate { get; set; }
        public TimeSpan AppoinmentTime { get; set; }
    }
}
