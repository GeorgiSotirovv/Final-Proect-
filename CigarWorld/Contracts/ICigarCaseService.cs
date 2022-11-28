using CigarWorld.Models.AddModels;
using CigarWorld.Models.JustModels;
using CigarWorld.Models.MyFavoriteViewModels;

namespace CigarWorld.Contracts
{
    public interface ICigarCaseService
    {
        Task<IEnumerable<CigarPocketCaseViewModel>> GetAllAsyncCigarCase();

        Task AddCigarCasesAsync(AddCigarPocketCaseViewModel model);

        Task AddCigarCaseToFavoritesAsync(int cigarPocketCaseId, string userId);

        Task<IEnumerable<MyFavoriteCigarPocketCaseViewModel>> GetMineCPCAsync(string userId);
    }
}
