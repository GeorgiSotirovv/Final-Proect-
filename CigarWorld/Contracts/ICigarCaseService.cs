using CigarWorld.Models.JustModels;

namespace CigarWorld.Contracts
{
    public interface ICigarCaseService
    {
        Task<IEnumerable<CigarPocketCase>> GetAllAsync();
    }
}
