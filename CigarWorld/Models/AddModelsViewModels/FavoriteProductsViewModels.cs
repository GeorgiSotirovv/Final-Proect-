using CigarWorld.Models.MyFavoriteViewModels;

namespace CigarWorld.Models.AddModels
{
    public class FavoriteProductsViewModels
    {
        public IEnumerable<MyFavoriteAshtrayViewModel> FavoriteAshtray { get; set; }// = new List<AddAshtrayViewModel>();
        public IEnumerable<MyFavoriteCigarPocketCaseViewModel> FavoriteCigarPoketCase { get; set; }// = new List<AddCigarPocketCaseViewModel>();
        public IEnumerable<MyFavoriteCigarilloViewModel> FavoriteCigarillo { get; set; }// = new List<AddCigarilloViewModel>();
        public IEnumerable<MyFavoriteCigarViewModel> FavoriteCigar { get; set; }// = new List<AddCigarViewModel>();
        public IEnumerable<MyFavoriteCutterViewModel> FavoriteCutter { get; set; }// = new List<AddCutterViewModel>();
        public IEnumerable<MyFavoriteHomidorViewModel> FavoriteHumidor { get; set; }// = new List<AddHumidorViewModel>();
        public IEnumerable<MyFavoriteLighterViewModel> FavoriteLighter { get; set; }// = new List<AddLighterViewModel>();
    }
}
