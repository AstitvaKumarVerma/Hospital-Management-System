namespace HMS_Web_APIs.Models.RequestModel
{
    public class GetAllDoctorAppoinments
    {
        public string title { get; set; } = null!;
        public string date { get; set; } 
        public TimeSpan? start { get; set; }
    }
}
