﻿using CigarWorld.Models.AddModels;
using CigarWorld.Models.JustModels;

namespace CigarWorld.Contracts
{
    public interface ILighterService
    {
        Task<IEnumerable<LighterViewModel>> GetAllAsync();

        Task AddLighterAsync(AddLighterViewModel model);

        Task AddFavoriteLighterAsync(int movieId, string userId);

        Task<IEnumerable<AddLighterViewModel>> GetMineLightersAsync(string userId);
    }
}
