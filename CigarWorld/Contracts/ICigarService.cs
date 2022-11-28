﻿using CigarWorld.Data.Models;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.Models;
using CigarWorld.Models.MyFavoriteViewModels;

namespace CigarWorld.Contracts
{
    public interface ICigarService
    {
        Task<IEnumerable<CigarViewModel>> GetAllCigarsAsync();

        Task<IEnumerable<StrengthType>> GetStrengthTypeAsync();

        Task AddCigarsAsync(AddCigarViewModel model);

        Task AddFavoriteCigarAsync(int movieId, string userId);

        Task<IEnumerable<MyFavoriteCigarViewModel>> GetMineCigarsAsync(string userId);
    }
}
