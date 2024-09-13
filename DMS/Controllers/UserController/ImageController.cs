using Disaster_Management_system.Models.UserModels;
using DMS.Areas.Identity.Data;
using DMS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Management_system.Controllers.UserController
{
    public class ImageController : Controller
    {

        private readonly DMSDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ImageController(DMSDbContext context, UserManager<ApplicationUser> userManager)
        {

            _context = context;
            this._userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }
        public class PhotoUploadViewModel
        {
            public string Description { get; set; }
            public DateTime Date { get; set; }
            public string VictimId { get; set; }
            public List<IFormFile> Photos { get; set; }
        }

        [HttpPost]
        public IActionResult Create([FromForm] PhotoUploadViewModel model)
        {
            var userId = _userManager.GetUserId(this.User);
            // Process each file in the Photos collection
            foreach (var photo in model.Photos)
            {
                if (photo != null && photo.Length > 0)
                {
                    // Optionally, process the file (e.g., save to disk or cloud storage)
                    using (var memoryStream = new MemoryStream())
                    {
                        photo.CopyToAsync(memoryStream);
                        var photoData = new PhotosViewModel
                        {
                            Description = model.Description,
                            Date = model.Date,
                            Url = Convert.ToBase64String(memoryStream.ToArray()),
                            user_id = userId
                        };

                        _context.Photos.Add(photoData);
                        _context.SaveChangesAsync();
                    }
                }
            }

            return Json(new { success = true });
        }




    }

}
