using CigarWorld.Models.Models;

namespace CigarWorld.Contracts
{
    public interface IAshtrayService
    {
        Task<IEnumerable<AshtrayViewModel>> GetAllAsync();

    }
}
