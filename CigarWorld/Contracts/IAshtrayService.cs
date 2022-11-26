using CigarWorld.Data.Models;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.BaseModels;

namespace CigarWorld.Contracts
{
    public interface IAshtrayService
    {
        Task<IEnumerable<AshtrayViewModel>> GetAllAshtrayAsync();

        Task<IEnumerable<AshtrayType>> GetTypesAsync();

        Task AddAshtraysAsync(AddAshtrayViewModel model);

        Task AddAshtrayToFavoritesAsync(int ashtrayId, string userId);

        Task<IEnumerable<AddAshtrayViewModel>> GetMineAshtrayAsync(string userId);
    }
}
