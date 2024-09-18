
using Disaster_Management_system.Models.UserModels;
using DMS.Areas.Identity.Data;
using DMS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Management_system.Controllers.UserController
{
    public class LocationController : Controller
    {
        private readonly DMSDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public LocationController(DMSDbContext context, UserManager<ApplicationUser> userManager)
        {

            _context = context;
            this._userManager = userManager;
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
                var userId = _userManager.GetUserId(this.User);
              
                var location = new LocationViewModel
                {
                    Id = Guid.NewGuid(),
                    Tole = model.Tole,
                    Province = model.Province,
                    District = model.District,
                    Municipality = model.Municipality,
                    Ward = model.Ward,
                    user_id = userId,
                    
                };

                _context.Locations.Add(location);
                await _context.SaveChangesAsync();
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
