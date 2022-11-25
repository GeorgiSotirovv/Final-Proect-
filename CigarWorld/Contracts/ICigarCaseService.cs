using CigarWorld.Models.AddModels;
using CigarWorld.Models.JustModels;

namespace CigarWorld.Contracts
{
    public interface ICigarCaseService
    {
        Task<IEnumerable<CigarPocketCaseViewModel>> GetAllAsyncCigarCase();

        Task AddCigarCasesAsync(AddCigarPocketCaseViewModel model);

        Task AddCigarCaseToFavoritesAsync(int cigarPocketCaseId, string userId);
    }
}
