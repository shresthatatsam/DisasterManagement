using DMS.Data.Interface;
using DMS.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMS.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {


        public readonly IVictim _victim;
        public DashboardController(IVictim victim)
        {

            _victim = victim;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.VictimCount = await _victim.CountVictimsAsync();
            return View();
        }
    }
}
