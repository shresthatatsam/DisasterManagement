using DMS.Areas.Identity.Data;
using DMS.Data;

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
        public virtual ICollection<DisasterViewModel> Disasters { get; set; } = new List<DisasterViewModel>();
        public virtual ICollection<LocationViewModel> Locations { get; set; } = new List<LocationViewModel>();
    }
}
