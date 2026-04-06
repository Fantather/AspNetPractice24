using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace AspNetPractice24.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public async Task Send(string message, string userName)
        {
            await Clients.All.SendAsync("Receive", message, userName);
        }
        [Authorize(Roles = "admin")]
        public async Task Notify(string message)
        {
            await Clients.All.SendAsync("Receive", message, "Admin");
        }


        public async Task Enter(string username, string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.All.SendAsync("Notify", $"{username} logged into the chat group {groupName}");
        }
        public async Task Send(string message, string userName, string groupName)
        {
            await Clients.Group(groupName).SendAsync("Receive", message, userName);
        }
    }
}