using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using CigarWorld.Models.JustModels;
using CigarWorld.Models.MyFavoriteViewModels;

namespace CigarWorld.Contracts
{
    public interface ICigarCaseService
    {
        Task<IEnumerable<AllCigarPocketCaseViewModel>> GetAllAsyncCigarCase(string userId);

        Task AddCigarCasesAsync(AddCigarPocketCaseViewModel model);

        Task AddCigarCaseToFavoritesAsync(int cigarPocketCaseId, string userName);

        Task<IEnumerable<MyFavoriteCigarPocketCaseViewModel>> GetMineCPCAsync(string userId);

        Task<CigarCaseDetailsViewModel> GetDetailsAsync(int CPCId, string userId);

        Task RemoveFromFavoritesAsync(int CPCId, string userId);

        Task RemoveFromDatabaseAsync(int CPCId);


        Task<EditCigarPocketCaseViewModel> GetInformationForCigarPocketCase(int CPCId);

        public void EditCigarPocketCaseInformation(EditCigarPocketCaseViewModel targetCPC);

        public CigarCaseDetailsViewModel AddReview(CigarCaseDetailsViewModel targetCPC, string UserName);

        public int DeleteReview(int reviewId);

        public int EditReview(int CPCId, string changedReview);
    }
}
