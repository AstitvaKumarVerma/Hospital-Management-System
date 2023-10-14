namespace HMS_Web_APIs.Models.ResponseModel
{
    public class ResponseForDoctorAppoinments<T> : Response
    {
        public List<T> DoctorBookedSlots { get; set; }
    }
}
