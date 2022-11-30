using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.JustModels;
using CigarWorld.Models.MyFavoriteViewModels;

namespace CigarWorld.Contracts
{
    public interface ILighterService
    {
        Task<IEnumerable<AllLighterViewModel>> GetAllAsync();

        Task AddLighterAsync(AddLighterViewModel model);

        Task AddFavoriteLighterAsync(int movieId, string userId);

        Task<IEnumerable<MyFavoriteLighterViewModel>> GetMineLightersAsync(string userId);

        Task<LighterDetailsViewModel> GetDetailsAsync(int lighterId);

        //Task RemoveFromFavoritesAsync(int lighterId, string userId);

        Task RemoveFromDatabaseAsync(int lighterId);
    }
}
