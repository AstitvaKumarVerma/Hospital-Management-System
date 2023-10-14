using System;
using System.Collections.Generic;

namespace HMS_Web_APIs.Models
{
    public partial class HmsChatMessagesTable
    {
        public int Id { get; set; }
        public int? SenderId { get; set; }
        public int? RecipientId { get; set; }
        public string? Text { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
