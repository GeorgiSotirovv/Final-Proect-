using CigarWorld.Data.Models;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.Models;

namespace CigarWorld.Contracts
{
    public interface ICigarService
    {
        Task<IEnumerable<CigarViewModel>> GetAllCigarsAsync();

        Task<IEnumerable<StrengthType>> GetStrengthTypeAsync();

        Task AddCigarsAsync(AddCigarViewModel model);
    }
}
