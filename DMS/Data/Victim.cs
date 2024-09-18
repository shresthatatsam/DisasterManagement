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
                    user_id = model.user_id
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


        [HttpGet]
        public async Task<VictimViewModel> getById(Guid id)
        {
           var victim = _context.Victims.Where(x => x.Id == id).FirstOrDefault();
            var disaster = _context.Disasters.Where(x => x.Id == id).FirstOrDefault();
            return victim;
           
        }

        public class AllDataDto
        {
            public string Name { get; set; }
            public string Age { get; set; }
            public string Gender { get; set; }
            public string ContactNumber { get; set; }
            public string Category { get; set; }
            public string Severity { get; set; }
            public string Date_Occured { get; set; }
            public bool Status { get; set; }

        }

        //public async Task<AllDataDto> getAllData()
        //{
          
        //}

    }
}
