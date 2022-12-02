using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using CigarWorld.Models.JustModels;
using CigarWorld.Models.MyFavoriteViewModels;

namespace CigarWorld.Contracts
{
    public interface IHumidorsService
    {
        Task<IEnumerable<AllHumidorViewModel>> GetAllAsync();

        Task AddHumidorAsync(AddHumidorViewModel model);

        Task AddFavoriteHumidorAsync(int movieId, string userId);

        Task<IEnumerable<MyFavoriteHomidorViewModel>> GetMineHumidorsAsync(string userId);

        Task<HumidorDetailsViewModel> GetDetailsAsync(int humidorId);

        //Task RemoveFromFavoritesAsync(int humidorId, string userId);

        Task RemoveFromDatabaseAsync(int humidorId);

        Task EditHumidor(int humidorId);

        Task<EditHumidorViewModel> GetInformationForHumidor(int humidorId);

        public void EditHumidorInformation(EditHumidorViewModel targetHumidor);
    }
}
