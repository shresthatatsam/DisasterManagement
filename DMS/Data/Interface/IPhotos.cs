using Disaster_Management_system.Models.UserModels;
using Microsoft.AspNetCore.Mvc;
using static Disaster_Management_system.Controllers.UserController.ImageController;

namespace DMS.Data.Interface
{
    public interface IPhotos
    {
        Task<PhotosViewModel> Create([FromForm] PhotoUploadViewModel model, PhotosViewModel photosViewModel);
    }
}
