using Disaster_Management_system.Models.AdminModels;
using Disaster_Management_system.Models.UserModels;
using DMS.Data.Interface;
using Microsoft.CodeAnalysis.Elfie.Model.Strings;
using Microsoft.EntityFrameworkCore;

namespace DMS.Data
{
    public class Victim :IVictim
    {
        public readonly DMSDbContext _context;
        public VictimViewModel Model { get; set; }
        public Victim(DMSDbContext context)
        {
            Model = new VictimViewModel();
            _context = context;
        }
        public async Task<VictimViewModel> CreateVictim(VictimViewModel model)
        {
            try
            {
                var victim = new VictimViewModel
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Age = model.Age,
                    Gender = model.Gender,
                    ContactNumber = model.ContactNumber,
                    Status = true,
                };

                _context.Victims.Add(victim);
                await _context.SaveChangesAsync();
                return victim;
            }
            catch (Exception ex)
            {
                // Optionally, log the exception or handle it accordingly
                throw new ApplicationException("An error occurred while creating the victim.", ex);
            }
        }

        public async Task<int> CountVictimsAsync()
        {
            // Count the number of victims asynchronously
            return await _context.Victims.CountAsync();
        }
    }
}
