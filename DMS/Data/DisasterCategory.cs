
using Disaster_Management_system.Data.Interface;
using Disaster_Management_system.Models.AdminModels;
using Disaster_Management_system.Models.UserModels;
using DMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Management_system.Data
{
    public class DisasterCategory : IDisasterCategory
    {
        public DisasterCategoryViewModel Model { get; set; }
        public readonly DMSDbContext _context;
        public DisasterCategory(DMSDbContext context)
        {

            Model = new DisasterCategoryViewModel();
            _context = context;
        }


        public DisasterCategoryViewModel Create(DisasterCategoryViewModel model)
        {

            // Map the ViewModel to your data model
            var disaster = new DisasterCategoryViewModel
            {
                Name = model.Name,
                Severity = model.Severity,
                CreatedDate = DateTime.Now,

            };

            // Save to the database
            _context.DisasterCategory.Add(disaster);
            _context.SaveChanges();

            return disaster;
        }

     
        public IEnumerable<DisasterCategoryViewModel> getAllDisasters()
        {
            var disasters = _context.DisasterCategory.Select(x => new DisasterCategoryViewModel
            {Id=x.Id,
                Name = x.Name,
                CreatedDate = x.CreatedDate,
                Severity = x.Severity
            }).ToList();
            return disasters;
        }

        public IEnumerable<DisasterCategoryViewModel> getDisastersByName(Guid id)
        {
            var disasters = _context.DisasterCategory.Where(x=>x.Id == id).Select(x => new DisasterCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreatedDate = x.CreatedDate,
                Severity = x.Severity
            });
            return disasters;
        }
    }
   
}
