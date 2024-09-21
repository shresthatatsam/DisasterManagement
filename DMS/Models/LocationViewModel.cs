using DMS.Areas.Identity.Data;

namespace Disaster_Management_system.Models.UserModels
{
    public class LocationViewModel
    {
        public Guid Id { get; set; }
        public string Tole { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Municipality { get; set; }
        public string Ward { get; set; }

        // Foreign keys
        public string user_id { get; set; }

        // Navigation properties
        public ApplicationUser user { get; set; }

        public Guid VictimId { get; set; }
        public virtual VictimViewModel Victim { get; set; }
    }
}
