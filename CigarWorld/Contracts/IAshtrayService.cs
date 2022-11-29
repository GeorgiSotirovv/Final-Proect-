using CigarWorld.Data.Models;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.BaseModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.MyFavoriteViewModels;

namespace CigarWorld.Contracts
{
    public interface IAshtrayService
    {
        Task<IEnumerable<AllAshtrayViewModel>> GetAllAshtrayAsync();

        Task<IEnumerable<AshtrayType>> GetTypesAsync();

        Task AddAshtraysAsync(AddAshtrayViewModel model);

        Task AddAshtrayToFavoritesAsync(int ashtrayId, string userId);

        Task<IEnumerable<MyFavoriteAshtrayViewModel>> GetMineAshtrayAsync(string userId);

        Task<AshtrayDetailsViewModel> GetDetailsAsync(int ashtrayId);
    }
}
