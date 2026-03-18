using Microsoft.AspNetCore.SignalR;

namespace AspNetPractice24.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync("Receive", message);
        }
    }
}
