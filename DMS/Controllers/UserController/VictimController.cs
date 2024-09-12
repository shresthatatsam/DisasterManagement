
using Disaster_Management_system.Models.UserModels;
using DMS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMS.Controllers.UserController
{
    public class VictimController : Controller
    {
        private readonly DMSDbContext _context;
        public VictimController(DMSDbContext context)
        {

            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VictimViewModel model)
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

            HttpContext.Session.SetString("VictimId", victim.Id.ToString());

            return RedirectToAction("Index", "Location");
        }
    }
}
