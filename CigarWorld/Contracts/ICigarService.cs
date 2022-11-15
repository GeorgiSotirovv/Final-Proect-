using CigarWorld.Models.Models;

namespace CigarWorld.Contracts
{
    public interface ICigarService
    {
        Task<IEnumerable<CigarViewModel>> GetAllAsync();
    }
}
