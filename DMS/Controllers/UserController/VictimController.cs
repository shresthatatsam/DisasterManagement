
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
        private readonly ILocation _Location;
        private readonly IDisaster _Disaster;
        private readonly UserManager<ApplicationUser> _userManager;

        public VictimController(IVictim victim , ILocation Location, IDisaster Disaster, UserManager<ApplicationUser> userManager)
        {

            _victim = victim;
            _Location = Location;
            _Disaster = Disaster;   
            this._userManager = userManager;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(VictimViewModel model)
        {
            model.user_id = _userManager.GetUserId(this.User);
           
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


        [HttpGet]
      public async Task<IActionResult> getAllData()
        {
           var item = _victim.getAllData();
            var result = new
            {
                Victim = item,
            };

            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> getDataById(Guid id)
        {
            var item = _victim.getDataById(id);
            var result = new
            {
                Victim = item,
            };

            return Json(result);
        }



    }
}
