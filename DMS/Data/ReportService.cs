using DMS.Data.Interface;

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
            var query = _context.Disasters.AsQueryable();

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
