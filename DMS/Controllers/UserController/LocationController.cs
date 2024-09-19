
using Disaster_Management_system.Models.UserModels;
using DMS.Areas.Identity.Data;
using DMS.Data;
using DMS.Data.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Management_system.Controllers.UserController
{
    public class LocationController : Controller
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        public ILocation _location;
        public LocationController(ILocation location, UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
            _location = location;   
        }

        public IActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Create(LocationViewModel model)
        {
            try
            {
                model.user_id = _userManager.GetUserId(this.User);
              
                await _location.Create(model);    
               
                return RedirectToAction("Index", "Disaster");
            }
            catch (Exception ex)
            {
                // Optionally, return a custom error view or message
                return StatusCode(500, "Internal server error");
            }
        }

       
    }
}
