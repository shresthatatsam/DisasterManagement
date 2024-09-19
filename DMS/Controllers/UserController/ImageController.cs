using Disaster_Management_system.Models.UserModels;
using DMS.Areas.Identity.Data;
using DMS.Data;
using DMS.Data.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Management_system.Controllers.UserController
{
    public class ImageController : Controller
    {

        private readonly IPhotos _Photos;
        private readonly UserManager<ApplicationUser> _userManager;

        public ImageController(IPhotos Photos, UserManager<ApplicationUser> userManager)
        {

            _Photos = Photos;   
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

        //[HttpPost]
        //public async IActionResult Create([FromForm] PhotoUploadViewModel model)
        //{
        //    var userId = _userManager.GetUserId(this.User);
        //    // Process each file in the Photos collection
        //    foreach (var photo in model.Photos)
        //    {
        //        if (photo != null && photo.Length > 0)
        //        {
        //            // Optionally, process the file (e.g., save to disk or cloud storage)
        //            using (var memoryStream = new MemoryStream())
        //            {
        //               await photo.CopyToAsync(memoryStream);
        //                var photoData = new PhotosViewModel
        //                {
        //                    Description = model.Description,
        //                    Date = model.Date,
        //                    Url = Convert.ToBase64String(memoryStream.ToArray()),
        //                    user_id = userId
        //                };

        //                _context.Photos.Add(photoData);
        //                _context.SaveChangesAsync();
        //            }
        //        }
        //    }

        //    return Json(new { success = true });
        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] PhotoUploadViewModel model , PhotosViewModel photosViewModel)
        {
           
            photosViewModel.user_id = _userManager.GetUserId(this.User);

           await _Photos.Create(model, photosViewModel);
            return Json(new { success = true });
        }



    }

}
