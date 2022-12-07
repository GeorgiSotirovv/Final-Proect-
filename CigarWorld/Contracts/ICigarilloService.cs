using CigarWorld.Data.Models;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using CigarWorld.Models.Models;
using CigarWorld.Models.MyFavoriteViewModels;

namespace CigarWorld.Contracts
{
    public interface ICigarilloService
    {
        Task<IEnumerable<AllCigarilloViewModel>> GetAllCigarillosAsync(string userId);

        Task<IEnumerable<FilterType>> GetTypesAsync();

        Task AddCigarilloAsync(AddCigarilloViewModel model);

        Task AddFavoriteCigarilloAsync(int movieId, string userId);

        Task<IEnumerable<MyFavoriteCigarilloViewModel>> GetMineCigarillosAsync(string userId);

        Task<CigarilloDetailsViewModel> GetDetailsAsync(int cigarilloId, string userId);

        Task RemoveFromFavoritesAsync(int cigarilloId, string userId);

        Task RemoveFromDatabaseAsync(int cigarilloId);

        Task EditCigarillo(int cigarilloId);

        Task<EditCigarilloViewModel> GetInformationForCigarillo(int cigarilloId);

        public void EditCigarilloInformation(EditCigarilloViewModel targetAshtray);

        public CigarilloDetailsViewModel AddReview(CigarilloDetailsViewModel targetCigarillo, string UserName);

        public int DeleteReview(int reviewId);

        public int EditReview(int cigarilloId, string changedReview);
    }
}
