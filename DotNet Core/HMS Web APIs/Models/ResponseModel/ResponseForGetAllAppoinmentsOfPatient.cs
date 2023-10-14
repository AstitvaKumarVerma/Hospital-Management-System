namespace HMS_Web_APIs.Models.ResponseModel
{
    public class ResponseForGetAllAppoinmentsOfPatient<T> : Response
    {
        public List<T> PatientAppoinments { get; set; }
    }
}
