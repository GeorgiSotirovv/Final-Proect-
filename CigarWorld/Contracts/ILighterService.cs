using CigarWorld.Models.JustModels;

namespace CigarWorld.Contracts
{
    public interface ILighterService
    {
        Task<IEnumerable<LighterViewModel>> GetAllAsync();
    }
}
