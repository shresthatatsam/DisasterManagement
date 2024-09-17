
using Disaster_Management_system.Models.UserModels;
using DMS.Areas.Identity.Data;
using DMS.Data;
using DMS.Data.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMS.Controllers.UserController
{
    public class VictimController : Controller
    {
        private readonly IVictim _victim;
        private readonly UserManager<ApplicationUser> _userManager;

        public VictimController(IVictim victim,UserManager<ApplicationUser> userManager)
        {

            _victim = victim;
            this._userManager = userManager;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(VictimViewModel model)
        //{
        //    try
        //    {
        //        var victim = new VictimViewModel
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = model.Name,
        //            Age = model.Age,
        //            Gender = model.Gender,
        //            ContactNumber = model.ContactNumber,
        //            Status = true,

        //        };

        //        _context.Victims.Add(victim);
        //        await _context.SaveChangesAsync();
        //    return RedirectToAction("Index", "Location");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Optionally, return a custom error view or message
        //        return StatusCode(500, "Internal server error");
        //    }

        //}

        [HttpPost]
        public async Task<IActionResult> Create(VictimViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Optionally return the view with model validation errors
            }

            try
            {
                await _victim.CreateVictim(model);
                return RedirectToAction("Index", "Location");
            }
            catch (ApplicationException ex)
            {
                // Optionally, return a custom error view or message
                return StatusCode(500, "Internal server error");
            }
        }


    }
}
