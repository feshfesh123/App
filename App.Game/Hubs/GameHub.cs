using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Game.Hubs
{
    public class GameHub : Hub
    {
        public async Task Send(string text)
        {
            await Clients.All.SendAsync("receive", text);
        }
    }
}
