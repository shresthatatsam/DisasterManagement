using Disaster_Management_system.Models.UserModels;
using DMS.Data;
using DMS.Data.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers.UserController
{
    public class PrintFormController : Controller
    {
     
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IVictim _victim;


        public PrintFormController(IHttpContextAccessor httpContextAccessor , IVictim victim)
        {
         
            this._httpContextAccessor = httpContextAccessor;
            this._victim = victim;
        }
        public IActionResult Index()
        {
            var victimIdString = _httpContextAccessor.HttpContext.Session.GetString("VictimId");
         
    if (Guid.TryParse(victimIdString, out Guid victimId))
    {
        var victimData = _victim.getDataById(victimId);

        // Return the victim data as JSON
        return Json(victimData);
    }
    else
    {
        // Return an error message as JSON if the victim ID is invalid
        return Json(new { success = false, message = "Invalid victim ID." });
    }
        }
    }
}
