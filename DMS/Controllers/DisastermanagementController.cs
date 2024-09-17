using Disaster_Management_system.Data.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    public class DisastermanagementController : Controller
    {

        private readonly IDisasterCategory _disasterService;

        // Constructor injection
        public DisastermanagementController(IDisasterCategory disasterService)
        {
            _disasterService = disasterService;
        }


        [Authorize(Roles = "Admin")]

        public IActionResult Index()
        {
            var disasters = _disasterService.getAllDisasters();
            return View(disasters);
        }
    }
}
