using CigarWorld.Models.JustModels;

namespace CigarWorld.Contracts
{
    public interface IHumidorsService
    {
        Task<IEnumerable<HumidorViewModel>> GetAllAsync();
    }
}
