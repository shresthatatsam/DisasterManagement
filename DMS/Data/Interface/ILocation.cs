using Disaster_Management_system.Models.UserModels;

namespace DMS.Data.Interface
{
    public interface ILocation
    {
        DisasterViewModel Model { get; set; }
        Task<LocationViewModel> Create(LocationViewModel model);
    }
}
