using Disaster_Management_system.Models.UserModels;
using DMS.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace DMS.Data
{
    public class ReportService :IReportService
    {
        public readonly DMSDbContext _context;

        public ReportService(DMSDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DisasterReport> GetDisasterReports(string disasterType, DateTime? startDate, DateTime? endDate)
        {
            var query = _context.Disasters.Include(x=>x.Victim).AsQueryable();

            // Filter by disaster type
            if (!string.IsNullOrEmpty(disasterType) && disasterType.ToLower() == "all")
            {
                query = query.Where(r => r.Category != disasterType);
            }
            else
            {
                query = query.Where(r => r.Category == disasterType);
            }

            return query.Select(r => new DisasterReport
            {
                Type = r.Category,
                VictimViewModel = new VictimViewModel
                {
                    Name = r.Victim.Name, // Assuming 'Name' is a property of Victim
                    Age = r.Victim.Age,
                    Gender = r.Victim.Gender,
                    ContactNumber =r.Victim.ContactNumber,
                    Locations = r.Victim.Locations,
                    Disasters = r.Victim.Disasters,
                },
                Date =Convert.ToDateTime(r.Date_Occured),
             
            }).ToList();
        }

        public IEnumerable<VictimReport> GetVictimReports(string location, string conditionStatus)
        {
            // Implement logic to fetch victim reports based on parameters
            return new List<VictimReport>(); // Replace with actual logic
        }

        public IEnumerable<ResourceReport> GetResourceReports(string resourceType)
        {
            // Implement logic to fetch resource reports based on parameters
            return new List<ResourceReport>(); // Replace with actual logic
        }

        public IEnumerable<UserReport> GetUserReports(string userRole)
        {
            // Implement logic to fetch user reports based on parameters
            return new List<UserReport>(); // Replace with actual logic
        }

        public IEnumerable<CustomReport> GetCustomReports(string customFilter)
        {
            // Implement logic to fetch custom reports based on parameters
            return new List<CustomReport>(); // Replace with actual logic
        }


    }
    public class DisasterReport
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public VictimViewModel VictimViewModel { get; set; }
    }

    public class VictimReport
    {
        public string Location { get; set; }
        public string ConditionStatus { get; set; }
        // Add more fields as necessary
    }

    public class ResourceReport
    {
        public string ResourceType { get; set; }
        // Add more fields as necessary
    }

    public class UserReport
    {
        public string UserRole { get; set; }
        // Add more fields as necessary
    }

    public class CustomReport
    {
        // Define fields according to your custom report needs
    }

}
