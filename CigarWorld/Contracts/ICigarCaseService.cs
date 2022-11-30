using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.JustModels;
using CigarWorld.Models.MyFavoriteViewModels;

namespace CigarWorld.Contracts
{
    public interface ICigarCaseService
    {
        Task<IEnumerable<AllCigarPocketCaseViewModel>> GetAllAsyncCigarCase();

        Task AddCigarCasesAsync(AddCigarPocketCaseViewModel model);

        Task AddCigarCaseToFavoritesAsync(int cigarPocketCaseId, string userId);

        Task<IEnumerable<MyFavoriteCigarPocketCaseViewModel>> GetMineCPCAsync(string userId);

        Task<CigarCaseDetailsViewModel> GetDetailsAsync(int CPCId);

       // Task RemoveFromFavoritesAsync(int CPCId, string userId);

        Task RemoveFromDatabaseAsync(int CPCId);
    }
}
