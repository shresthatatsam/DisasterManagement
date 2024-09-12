
using Disaster_Management_system.Models.UserModels;
using DMS.Areas.Identity.Data;
using DMS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMS.Controllers.UserController
{
    public class VictimController : Controller
    {
        private readonly DMSDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public VictimController(DMSDbContext context,UserManager<ApplicationUser> userManager)
        {

            _context = context;
            this._userManager = userManager;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VictimViewModel model)
        {
            try
            {
                var victim = new VictimViewModel
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Age = model.Age,
                    Gender = model.Gender,
                    ContactNumber = model.ContactNumber,
                    Status = true,

                };

                _context.Victims.Add(victim);
                await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Location");
            }
            catch (Exception ex)
            {
                // Optionally, return a custom error view or message
                return StatusCode(500, "Internal server error");
            }

        }


    }
}
