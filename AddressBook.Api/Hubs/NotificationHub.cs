using AddressBook.Api.Models.Notification;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace AddressBook.Api.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task BroadcastMessage(NotificationModel message)
        {
            await Clients.All.SendAsync("BroadcastMessage", message);
        }
    }
}
