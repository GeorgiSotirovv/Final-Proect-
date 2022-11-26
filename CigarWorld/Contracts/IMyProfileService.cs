using CigarWorld.Models.AddModels;

namespace CigarWorld.Contracts
{
    public interface IMyProfileService
    {
        FavoriteProductsViewModels GetAllFavoriteProductsViewModels(string userId);
    }
}
