using CigarWorld.Models.AddModels;
using CigarWorld.Models.JustModels;

namespace CigarWorld.Contracts
{
    public interface IHumidorsService
    {
        Task<IEnumerable<HumidorViewModel>> GetAllAsync();

        Task AddHumidorAsync(AddHumidorViewModel model);

        Task AddFavoriteHumidorAsync(int movieId, string userId);
    }
}
