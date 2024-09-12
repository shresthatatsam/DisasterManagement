
using Disaster_Management_system.Models.UserModels;
using DMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Management_system.Controllers.UserController
{
    public class DisasterController : Controller
    {
        private readonly DMSDbContext _context;

     
        public DisasterController(DMSDbContext context) 
        {
            
            _context = context;
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
            var userIdString = HttpContext.Session.GetString("VictimId");

            Guid userId;
            if (Guid.TryParse(userIdString, out userId))
            {
                ViewBag.UserId = userId;
            }
            else
            {
                ViewBag.UserId = Guid.Empty;
            }
            var disaster = new DisasterViewModel
            {
                Id = Guid.NewGuid(),
                Category = model.Category,
                Severity = model.Severity,
                Date_Occured = DateTime.UtcNow.ToString("yyyy-MM-dd"),
                VictimId = userId
            };

            _context.Disasters.Add(disaster);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Image");
        }


    }
}
