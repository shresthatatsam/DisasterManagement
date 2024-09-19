
using Disaster_Management_system.Models.UserModels;
using DMS.Areas.Identity.Data;
using DMS.Data;
using DMS.Data.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Management_system.Controllers.UserController
{
    public class DisasterController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public IDisaster _disaster;
        public DisasterController(IDisaster disaster, UserManager<ApplicationUser> userManager) 
        {
            
           this._disaster = disaster;
            this._userManager = userManager;
        }

        public IActionResult Index()
        {
            //var disasterList = _disasterCategory.getAllDisasters();
            return View();
           
        }

       

        [HttpPost]
        public async Task<IActionResult> Create(DisasterViewModel model)
        {
            try
            {
             

                model.user_id = _userManager.GetUserId(this.User);

               await _disaster.Create(model);
               
                return RedirectToAction("Index", "Image");
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }


    }
}
