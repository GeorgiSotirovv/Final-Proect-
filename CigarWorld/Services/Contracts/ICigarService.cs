using CigarWorld.Data.Models;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using CigarWorld.Models.Models;
using CigarWorld.Models.MyFavoriteViewModels;

namespace CigarWorld.Contracts
{
    public interface ICigarService
    {
        Task<IEnumerable<AllCigarViewModel>> GetAllCigarsAsync(string userId);

        Task<IEnumerable<StrengthType>> GetStrengthTypeAsync();

        Task AddCigarsAsync(AddCigarViewModel model);

        Task AddFavoriteCigarAsync(int movieId, string userId);

        Task<IEnumerable<MyFavoriteCigarViewModel>> GetMineCigarsAsync(string userId);

        Task<CigarDetailsViewModel> GetDetailsAsync(int cigarId, string userName);

        Task RemoveFromFavoritesAsync(int cigarId, string userId);

        Task RemoveFromDatabaseAsync(int cigarId);

        Task EditCigar(int cigarId);

        Task<EditCigarViewModel> GetInformationForCigar(int cigarId);

        public void EditCigarInformation(EditCigarViewModel targetCigar);

        public CigarDetailsViewModel AddReview(CigarDetailsViewModel targetCigar, string UserName);

        public int DeleteReview(int reviewId);

        public int EditReview(int cigarId, string changedReview);
    }
}
