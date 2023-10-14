using HMS_Web_APIs.Features.Patient.Command;
using HMS_Web_APIs.Models;
using HMS_Web_APIs.Models.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace HMS_Web_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _chatHubContext;
        private readonly sdirectdbContext _dbContext;

        public ChatController(IHubContext<ChatHub> chatHubContext, sdirectdbContext dbContext)
        {
            _chatHubContext = chatHubContext;
            _dbContext = dbContext;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] ChatMessageModel message)
        {
            // Add logic to authenticate and determine the recipient doctor's ID
            int doctorId = message.RecipientId; // Extract doctor ID from the message model

            // Save the message to the database                     
            var chatMessage = new HmsChatMessagesTable
            {
                SenderId = message.SenderId,
                RecipientId = doctorId,
                Text = message.Text,
                Timestamp = DateTime.UtcNow
            };
            _dbContext.HmsChatMessagesTables.Add(chatMessage);
            await _dbContext.SaveChangesAsync();

            // Send the message to the doctor using SignalR
            await _chatHubContext.Clients.User(doctorId.ToString()).SendAsync("ReceiveMessage", message.Text);

            return Ok();
        }
    }
}
