using CigarWorld.Models.MyFavoriteViewModels;

namespace CigarWorld.Contracts
{
    public interface IMyProfileService
    {
        FavoriteProductsViewModels GetAllFavoriteProductsViewModels(string userId);
    }
}
