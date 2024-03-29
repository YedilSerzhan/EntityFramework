﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Milestone2.Hubs
{
    public class myHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public myHub()
        {
        }
    }
}
