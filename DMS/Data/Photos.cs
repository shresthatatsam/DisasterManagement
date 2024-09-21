using Disaster_Management_system.Models.UserModels;
using DMS.Data.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Disaster_Management_system.Controllers.UserController.ImageController;

namespace DMS.Data
{
    public class Photos :IPhotos
    {
        public readonly DMSDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DisasterViewModel Model { get; set; }


        public Photos(DMSDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            Model = new DisasterViewModel();
            _context = context;
            this._httpContextAccessor = httpContextAccessor;

        }


        [HttpPost]
        public async Task<PhotosViewModel> Create([FromForm] PhotoUploadViewModel model , PhotosViewModel photosViewModel)
        {
            try
            {
                var victimId = _httpContextAccessor.HttpContext.Session.GetString("VictimId");

                if (string.IsNullOrEmpty(victimId))
                {
                    throw new ApplicationException("Victim ID is not found in session.");
                }

                var existingRecord = _context.Photos
                    .Where(x => x.VictimId == Guid.Parse(victimId)).ToList();
                if (existingRecord.Count>0)
                {
                    foreach (var record in existingRecord)
                    {
                        _context.Photos.RemoveRange(record);
                    }
                    
                }
              
                   foreach (var photo in model.Photos)
                    {
                        if (photo != null && photo.Length > 0)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await photo.CopyToAsync(memoryStream);

                                var photoData = new PhotosViewModel
                                {
                                    Description = model.Description,
                                    Date = model.Date,
                                    Url = Convert.ToBase64String(memoryStream.ToArray()),
                                    user_id = photosViewModel.user_id,
                                    VictimId = Guid.Parse(victimId),
                                };

                                await _context.Photos.AddAsync(photoData);
                            }
                        }
                    }

                    await _context.SaveChangesAsync();
               
                    return photosViewModel;

            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                throw new ApplicationException("An error occurred while handling the disaster record.", ex);
            }

        }

    }
}
