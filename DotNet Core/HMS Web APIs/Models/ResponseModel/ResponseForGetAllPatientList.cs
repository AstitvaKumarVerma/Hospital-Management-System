namespace HMS_Web_APIs.Models.ResponseModel
{
    public class ResponseForGetAllPatientList<T> :Response
    {
        public List<T> PatientsData { get; set; }
    }
}
