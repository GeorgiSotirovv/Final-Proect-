using CigarWorld.Data.Models;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.Models;

namespace CigarWorld.Contracts
{
    public interface ICigarilloService
    {
        Task<IEnumerable<CigarilloViewModel>> GetAllCigarillosAsync();

        Task<IEnumerable<FilterType>> GetTypesAsync();

        Task AddCigarilloAsync(AddCigarilloViewModel model);

        //Task AddFavoriteCigarilloAsync(int movieId, string userId);
    }
}
