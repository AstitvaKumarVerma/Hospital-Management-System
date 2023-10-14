namespace HMS_Web_APIs.Models.ResponseModel
{
    public class ResponseForGetAllDoctorList<T> :Response
    {
        public List<T> DoctorsData { get; set; }

    }
}
