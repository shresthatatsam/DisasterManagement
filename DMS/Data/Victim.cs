using Disaster_Management_system.Models.AdminModels;
using Disaster_Management_system.Models.UserModels;
using DMS.Areas.Identity.Data;
using DMS.Data.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Model.Strings;
using Microsoft.EntityFrameworkCore;

namespace DMS.Data
{
    public class Victim :IVictim
    {
        public readonly DMSDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public VictimViewModel Model { get; set; }



        public Victim(DMSDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            Model = new VictimViewModel();
            _context = context;
            this._httpContextAccessor = httpContextAccessor;
        }
       
       public async Task<VictimViewModel> CreateVictim(VictimViewModel model)
        {
            try
            {
                // Check if a victim with the same contact number already exists
                var existingVictim = await _context.Victims
                    .FirstOrDefaultAsync(x => x.ContactNumber == model.ContactNumber);

                if (existingVictim != null)
                {
                    existingVictim.Name = model.Name;
                    existingVictim.Age = model.Age;
                    existingVictim.Gender = model.Gender;
                    existingVictim.Status = true; 
                    existingVictim.user_id = model.user_id;
                    _context.Victims.Update(existingVictim);
                    await _context.SaveChangesAsync();
                    _httpContextAccessor.HttpContext.Session.SetString("VictimId", existingVictim.Id.ToString());
                    return existingVictim;
                }
                else
                {
                    var victim = new VictimViewModel
                    {
                        Id = Guid.NewGuid(),
                        Name = model.Name,
                        Age = model.Age,
                        Gender = model.Gender,
                        ContactNumber = model.ContactNumber,
                        Status = true,
                        user_id = model.user_id,
                    };

                    _context.Victims.Add(victim);
                    await _context.SaveChangesAsync();
                    _httpContextAccessor.HttpContext.Session.SetString("VictimId", victim.Id.ToString());
                    return victim;

                }
               
               
            }
            catch (Exception ex)
            {
                // Optionally, log the exception or handle it accordingly
                throw new ApplicationException("An error occurred while creating or updating the victim.", ex);
            }
        }




        public async Task<int> CountVictimsAsync()
        {
            // Count the number of victims asynchronously
            return await _context.Victims.CountAsync();
        }


        [HttpGet]
        public async Task<List<VictimViewModel>> getAllData()
        {
           var victim = _context.Victims.Select(x => new VictimViewModel
           {
               Id=x.Id,
               Name = x.Name,
               Gender=x.Gender,
               ContactNumber = x.ContactNumber, 
               Status=x.Status,
               Age = x.Age,
               Disasters = x.Disasters,
               Locations = x.Locations,
               
           }).ToList();
           return victim;
        }

      

       
    }
}
