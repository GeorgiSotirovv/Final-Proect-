using CigarWorld.Data.Models;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using CigarWorld.Models.Models;
using CigarWorld.Models.MyFavoriteViewModels;

namespace CigarWorld.Contracts
{
    public interface ICutterService
    {
        Task<IEnumerable<AllCutterViewModel>> GetAllAsync();

        Task<IEnumerable<CutterType>> GetTypesAsync();

        Task AddCutterAsync(AddCutterViewModel model);

        Task AddFavoriteCutterAsync(int movieId, string userId);

        Task<IEnumerable<MyFavoriteCutterViewModel>> GetMineCuttersAsync(string userId);

        Task<CutterDetailsViewModel> GetDetailsAsync(int cutterId, string curUser);

        Task RemoveFromFavoritesAsync(int cutterId, string userId);

        Task RemoveFromDatabaseAsync(int cutterId);

        Task EditCutter(int cutterId);

        Task<EditCutterViewModel> GetInformationForCutter(int cutterId);

        public void EditCutterInformation(EditCutterViewModel cutterId);

        public CutterDetailsViewModel AddReview(CutterDetailsViewModel targetCutter, string UserName);

        public int DeleteReview(int reviewId);

        public int EditReview(int cutterId, string changedReview);
    }
}
