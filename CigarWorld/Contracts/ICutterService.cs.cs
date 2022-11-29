using CigarWorld.Data.Models;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
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

        Task<CutterDetailsViewModel> GetDetailsAsync(int cutterId);
    }
}
