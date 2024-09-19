using Disaster_Management_system.Models.UserModels;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Data.Interface
{
    public interface IDisaster
    {
        DisasterViewModel Model { get; set; }
        Task<DisasterViewModel> Create(DisasterViewModel model);
    }
}
