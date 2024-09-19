using Disaster_Management_system.Models.UserModels;
using DMS.Areas.Identity.Data;
using DMS.Data.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Data
{
    public class Location :ILocation
    {
        public readonly DMSDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DisasterViewModel Model { get; set; }

       


        public Location(DMSDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            Model = new DisasterViewModel();
            _context = context;
            this._httpContextAccessor = httpContextAccessor;
            
        }


        public async Task<LocationViewModel> Create(LocationViewModel model)
        {
            try
            {
                var victimId = _httpContextAccessor.HttpContext.Session.GetString("VictimId");

                if (string.IsNullOrEmpty(victimId))
                {
                    throw new ApplicationException("Victim ID is not found in session.");
                }
                var existingRecord = _context.Locations
                   .Where(x => x.VictimId == Guid.Parse(victimId)).FirstOrDefault();
                if (existingRecord != null)
                {
                    // Update existing record
                    existingRecord.Tole = model.Tole;
                    existingRecord.Province = model.Province;
                    existingRecord.District = model.District;
                    existingRecord.Municipality = model.Municipality;
                    existingRecord.Ward = model.Ward;
                    existingRecord.user_id = model.user_id;

                    _context.Locations.Update(existingRecord);
                }
                else
                {
                   
                    var location = new LocationViewModel
                    {
                        Id = Guid.NewGuid(),
                        Tole = model.Tole,
                        Province = model.Province,
                        District = model.District,
                        Municipality = model.Municipality,
                        Ward = model.Ward,
                        user_id = model.user_id,
                        VictimId = Guid.Parse(victimId)
                    };

                    await _context.Locations.AddAsync(location);
                }

                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while handling the disaster record.", ex);
            }
        }


    }
}
