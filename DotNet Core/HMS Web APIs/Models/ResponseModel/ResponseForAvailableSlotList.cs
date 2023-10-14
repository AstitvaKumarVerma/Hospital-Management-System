namespace HMS_Web_APIs.Models.ResponseModel
{
    public class ResponseForAvailableSlotList<T> : Response
    {
        public List<T> AvailableSlots { get; set; }
    }
}
