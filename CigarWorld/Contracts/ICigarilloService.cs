using CigarWorld.Data.Models;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.Models;
using CigarWorld.Models.MyFavoriteViewModels;

namespace CigarWorld.Contracts
{
    public interface ICigarilloService
    {
        Task<IEnumerable<AllCigarilloViewModel>> GetAllCigarillosAsync();

        Task<IEnumerable<FilterType>> GetTypesAsync();

        Task AddCigarilloAsync(AddCigarilloViewModel model);

        Task AddFavoriteCigarilloAsync(int movieId, string userId);

        Task<IEnumerable<MyFavoriteCigarilloViewModel>> GetMineCigarillosAsync(string userId);

        Task<CigarilloDetailsViewModel> GetDetailsAsync(int cigarilloId);

        //Task RemoveFromFavoritesAsync(int cigarilloId, string userId);

        Task RemoveFromDatabaseAsync(int cigarilloId);
    }
}
