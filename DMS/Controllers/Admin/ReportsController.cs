using DMS.Data.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class ReportsController : Controller
    {



        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
           _reportService = reportService;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GenerateDisasterReport(string disasterType, DateTime? startDate, DateTime? endDate)
        {
            var reports = _reportService.GetDisasterReports(disasterType, startDate, endDate);
            return Json(reports);
        }


        [HttpPost]
        public IActionResult GenerateVictimReport(string location, string conditionStatus)
        {
            var reports = _reportService.GetVictimReports(location, conditionStatus);
            return Json(reports);
        }

        [HttpPost]
        public IActionResult GenerateResourceReport(string resourceType)
        {
            var reports = _reportService.GetResourceReports(resourceType);
            return Json(reports);
        }

        [HttpPost]
        public IActionResult GenerateUserReport(string userRole)
        {
            var reports = _reportService.GetUserReports(userRole);
            return Json(reports);
        }

        [HttpPost]
        public IActionResult GenerateCustomReport(string customFilter)
        {
            var reports = _reportService.GetCustomReports(customFilter);
            return Json(reports);
        }
    }
}
