using CigarWorld.Models.BaseModels;

namespace CigarWorld.Contracts
{
    public interface IAshtrayService
    {
        Task<IEnumerable<AshtrayViewModel>> GetAllAsync();

    }
}
