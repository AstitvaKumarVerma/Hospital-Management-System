namespace HMS_Web_APIs.Models.RequestModel
{
    public class ChatMessageModel
    {
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
