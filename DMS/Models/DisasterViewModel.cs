

using DMS.Areas.Identity.Data;

namespace Disaster_Management_system.Models.UserModels
{
    public class DisasterViewModel
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Severity { get; set; }
        public string Date_Occured { get; set; }

        // Foreign keys
        public string user_id { get; set; }

        // Navigation properties
        public ApplicationUser user { get; set; }
    }
}
