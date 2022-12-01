using CigarWorld.Data.Models;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.BaseModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using CigarWorld.Models.MyFavoriteViewModels;

namespace CigarWorld.Contracts
{
    public interface IAshtrayService
    {
        Task<IEnumerable<AllAshtrayViewModel>> GetAllAshtrayAsync();

        Task<IEnumerable<AshtrayType>> GetTypesAsync();

        Task AddAshtraysAsync(AddAshtrayViewModel model);

        Task AddAshtrayToFavoritesAsync(int ashtrayId, string userId);

        Task<IEnumerable<MyFavoriteAshtrayViewModel>> GetMineAshtrayAsync(string userId);

        Task<AshtrayDetailsViewModel> GetDetailsAsync(int ashtrayId, string userName);

        Task RemoveFromFavoritesAsync(int ashtrayId, string userId);

        Task RemoveFromDatabaseAsync(int ashtrayId);

        Task EditAshtray(int ashtrayId);

        Task <EditAshtrayViewModel> GetInformationForAshtray(int ashtrayId);

        public void EdidAshtaryInformation(EditAshtrayViewModel targetAshtray);

        public AshtrayDetailsViewModel AddReview(AshtrayDetailsViewModel targetAshtray, string UserName);

        public int DeleteReview(int reviewId);
    }
}
