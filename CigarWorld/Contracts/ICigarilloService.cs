using CigarWorld.Models.Models;

namespace CigarWorld.Contracts
{
    public interface ICigarilloService
    {
        Task<IEnumerable<CigarilloViewModel>> GetAllAsync();
    }
}
