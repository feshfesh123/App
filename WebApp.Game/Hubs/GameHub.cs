using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Game.Data;
using WebApp.Game.Entities;

namespace WebApp.Game.Hubs
{
    public class GameHub : Hub
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;

        public GameHub(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task Join(string userName)
        {
            var curUser = await userManager.FindByNameAsync(userName);
            var joined = context.Joiners.Where(x => x.UserId == curUser.Id).FirstOrDefault();
            if (joined == null)
            {
                Joiner newJoin = new Joiner();
                newJoin.UserId = curUser.Id;
                newJoin.User = curUser;
                newJoin.Id = Guid.NewGuid().ToString();
                await context.Joiners.AddAsync(newJoin);
                await context.SaveChangesAsync();
                await Clients.All.SendAsync("join", userName);
            }
            else
            {
                context.Joiners.Remove(joined);
                await context.SaveChangesAsync();
                await Clients.All.SendAsync("receive", userName);
            }
        }
    }
}
