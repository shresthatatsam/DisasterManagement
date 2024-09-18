using DMS.Areas.Identity.Data;

namespace Disaster_Management_system.Models.UserModels
{
    public class VictimViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public bool Status { get; set; }
        public string user_id { get; set; }

        // Navigation properties
        public ApplicationUser user { get; set; }
               public DisasterViewModel Disasters { get; set; }
    }
}
