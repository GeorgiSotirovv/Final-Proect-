using CigarWorld.Models.AddModels;
using CigarWorld.Models.JustModels;
using CigarWorld.Models.MyFavoriteViewModels;

namespace CigarWorld.Contracts
{
    public interface IHumidorsService
    {
        Task<IEnumerable<HumidorViewModel>> GetAllAsync();

        Task AddHumidorAsync(AddHumidorViewModel model);

        Task AddFavoriteHumidorAsync(int movieId, string userId);

        Task<IEnumerable<MyFavoriteHomidorViewModel>> GetMineHumidorsAsync(string userId);
    }
}
