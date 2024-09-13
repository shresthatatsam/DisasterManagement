using DMS.Areas.Identity.Data;

namespace Disaster_Management_system.Models.UserModels
{
    public class PhotosViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }


        // Foreign keys
        public string user_id { get; set; }

        // Navigation properties
        public ApplicationUser user { get; set; }
    }
}
