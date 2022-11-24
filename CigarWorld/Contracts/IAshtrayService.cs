using CigarWorld.Data.Models;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.BaseModels;

namespace CigarWorld.Contracts
{
    public interface IAshtrayService
    {
        //int Create(
        //    string Brand,
        //    string CountryOfManufacturing,
        //    string ImageUrl,
        //    string Comment,
        //    int AshtrayId);

        Task<IEnumerable<AshtrayViewModel>> GetAllAshtrayAsync();

        Task<IEnumerable<AshtrayType>> GetTypesAsync();

        Task AddAshtraysAsync(AddAshtrayViewModel model);

        //Task AddAshtrayToCollectionAsync(int ashtrayId, string userId);


    }
}
