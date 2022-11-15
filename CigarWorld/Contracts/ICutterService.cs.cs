using CigarWorld.Models.Models;

namespace CigarWorld.Contracts
{
    public interface ICutterService
    {
        Task<IEnumerable<CutterViewModel>> GetAllAsync();
    }
}
