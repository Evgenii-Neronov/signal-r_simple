﻿using Microsoft.AspNetCore.SignalR;

namespace SignalRHubService.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task SendNotification(string message, string groupName)
        {
            if(groupName == "ALL")
            {
                await Clients.All.SendAsync("ReceiveNotification", message);
            }
            else
            {
                await Clients.Group(groupName).SendAsync("ReceiveNotification", message);
            }
        }

    }
}
