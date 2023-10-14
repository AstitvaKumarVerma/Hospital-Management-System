using Microsoft.AspNetCore.SignalR;

namespace HMS_Web_APIs.Features.Patient.Command
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string doctorId, string message)
        {
            // Handle the message and send it to the appropriate client (doctor)
            await Clients.User(doctorId).SendAsync("ReceiveMessage", message);
        }
    }
}
