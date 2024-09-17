using Disaster_Management_system.Models.AdminModels;
using DMS.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace DMS.Data
{
    public class Dashboard :IDashboard
    {
    //public readonly{ get; set; }
    public readonly DMSDbContext _context;

        public readonly IVictim _victim;
        public Dashboard(DMSDbContext context, IVictim victim)
        {

            _context = context;
            _victim = victim;
        }




    }
}
