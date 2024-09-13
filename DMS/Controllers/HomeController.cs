using System.Diagnostics;
using DMS.Areas.Identity.Data;
using DMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    [Authorize (Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger , UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            this._userManager = userManager;
        }

        public IActionResult Index()
        {
            var user =  _userManager.GetUserAsync(this.User);

            // Check if user is not null
            if (user != null)
            {
                // Store the user's first name in ViewData
                ViewData["FirstName"] = user.Result.FirstName; // Assuming ApplicationUser has a FirstName property
            }
            else
            {
                // Handle the case where the user is not found or not logged in
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
