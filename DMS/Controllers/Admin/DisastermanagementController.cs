using Disaster_Management_system.Data.Interface;
using Disaster_Management_system.Models.AdminModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers.Admin
{
    //[Authorize(Roles = "Admin")]
    public class DisastermanagementController : Controller
    {

        private readonly IDisasterCategory _disasterService;

        // Constructor injection
        public DisastermanagementController(IDisasterCategory disasterService)
        {
            _disasterService = disasterService;
        }


       

        public IActionResult Index()
        {
            var disasters = _disasterService.getAllDisasters();
            return View(disasters);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var disasters = _disasterService.getAllDisasters();

            return Json(disasters);
        }

        [HttpGet]
        public IActionResult getDisasterCategoryByName(Guid id)
        {
      
            var disasters = _disasterService.getDisastersByName(id);

            return Json(disasters);
        }

        [HttpPost]
        public IActionResult Create(DisasterCategoryViewModel disasterCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                _disasterService.Create(disasterCategoryViewModel); // Save the disaster
                var allDisasters = _disasterService.getAllDisasters(); // Get the updated list
                return Json(allDisasters); // Return as JSON
            }

            return BadRequest(ModelState); // Return bad request if the model state is invalid
        }

    }
}
