
using Disaster_Management_system.Models.UserModels;
using DMS.Areas.Identity.Data;
using DMS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Management_system.Controllers.UserController
{
    public class DisasterController : Controller
    {
        private readonly DMSDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DisasterController(DMSDbContext context, UserManager<ApplicationUser> userManager) 
        {
            
            _context = context;
            this._userManager = userManager;
        }

        public IActionResult Index()
        {
            //var disasterList = _disasterCategory.getAllDisasters();
            return View();
           
        }

        //[HttpGet]
        //public IActionResult GetDisasterDropdownOptions()
        //{
        //    var disasterList = _disasterCategory.getAllDisasters();

        //    return View("Index" , disasterList);
        //}

        //[HttpGet]
        //public IActionResult getDisasterCategoryByName(Guid id)
        //{
        //   //var data= _disasterCategory.getDisastersByName(id);
        //    return Json();
        //}


        [HttpPost]
        public async Task<IActionResult> Create(DisasterViewModel model)
        {


            var userId = _userManager.GetUserId(this.User);

            var disaster = new DisasterViewModel
            {
                Id = Guid.NewGuid(),
                Category = model.Category,
                Severity = model.Severity,
                Date_Occured = DateTime.UtcNow.ToString("yyyy-MM-dd"),
                user_id = userId
            };

            _context.Disasters.Add(disaster);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Image");
        }


    }
}
