using System.Diagnostics;
using Disaster_Management_system.Data.Interface;
using DMS.Areas.Identity.Data;
using DMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDisasterCategory _disasterCategory;

        public HomeController(ILogger<HomeController> logger , UserManager<ApplicationUser> userManager, IDisasterCategory disasterCategory)
        {
            _logger = logger;
            this._userManager = userManager;
            this._disasterCategory = disasterCategory;
        }

        public IActionResult Index()
        {
            var user =  _userManager.GetUserAsync(this.User);

            if (user != null)
            {
                ViewData["FirstName"] = user.Result.FirstName; 
            }
            else
            {
                ViewData["FirstName"] = "Guest";
            }

            return View();
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
