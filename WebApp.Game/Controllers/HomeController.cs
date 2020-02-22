using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApp.Game.Data;
using WebApp.Game.Entities;
using WebApp.Game.Hubs;
using WebApp.Game.Models;

namespace WebApp.Game.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        

        public HomeController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var curUser = await _userManager.GetUserAsync(User);
                ViewBag.currentUserName = curUser.UserName;
            }

            var joiners = await _context.Joiners.Include(x => x.User).ToListAsync();
            return View(joiners);
        }

        public async Task<IActionResult> Join()
        {
            var curUser = await _userManager.GetUserAsync(User);
            var joined = _context.Joiners.Where(x => x.UserId == curUser.Id).FirstOrDefault();
            if (joined == null)
            {
                Joiner newJoin = new Joiner();
                newJoin.UserId = curUser.Id;
                await _context.Joiners.AddAsync(newJoin);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
