﻿using Disaster_Management_system.Models.UserModels;
using DMS.Areas.Identity.Data;
using DMS.Data.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMS.Data
{
    public class Disaster :IDisaster
    {
        public readonly DMSDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DisasterViewModel Model { get; set; }


        public Disaster(DMSDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            Model = new DisasterViewModel();
            _context = context;
            this._httpContextAccessor = httpContextAccessor;
            
        }

        [HttpPost]
        public async Task<DisasterViewModel> Create(DisasterViewModel model)
        {
            try
            {
                var victimId = _httpContextAccessor.HttpContext.Session.GetString("VictimId");

                if (string.IsNullOrEmpty(victimId))
                {
                    throw new ApplicationException("Victim ID is not found in session.");
                }

                var existingRecord = _context.Disasters
                    .Where(x => x.VictimId == Guid.Parse(victimId)).FirstOrDefault();

                if (existingRecord != null)
                {
                    // Update existing record
                    existingRecord.Category = model.Category;
                    existingRecord.Severity = model.Severity;
                    existingRecord.Date_Occured = DateTime.UtcNow.ToString("yyyy-MM-dd");
                    existingRecord.user_id = model.user_id;

                    _context.Disasters.Update(existingRecord);
                    await _context.SaveChangesAsync();

                    return existingRecord;
                }
                else
                {
                    // Create new record
                    var disaster = new DisasterViewModel
                    {
                        Id = Guid.NewGuid(),
                        Category = model.Category,
                        Severity = model.Severity,
                        Date_Occured = DateTime.UtcNow.ToString("yyyy-MM-dd"),
                        user_id = model.user_id,
                        VictimId = Guid.Parse(victimId)
                    };

                    _context.Disasters.Add(disaster);
                     await _context.SaveChangesAsync();
                return disaster;
                }

            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                throw new ApplicationException("An error occurred while handling the disaster record.", ex);
            }

        }


    }
}
