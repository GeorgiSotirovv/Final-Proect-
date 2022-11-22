using CigarWorld.Models.AddModels;
using CigarWorld.Models.JustModels;

namespace CigarWorld.Contracts
{
    public interface ILighterService
    {
        Task<IEnumerable<LighterViewModel>> GetAllAsync();

        Task AddLighterAsync(AddLighterViewModel model);
    }
}
