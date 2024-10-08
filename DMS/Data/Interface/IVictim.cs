﻿using Disaster_Management_system.Models.UserModels;

namespace DMS.Data.Interface
{
    public interface IVictim
    {
        Task<VictimViewModel> CreateVictim(VictimViewModel model);
        Task<int> CountVictimsAsync();

        Task<List<VictimViewModel>> getAllData();
    }
}
