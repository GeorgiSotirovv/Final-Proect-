namespace CigarWorld.Models.AddModels
{
    public class FavoriteProductsViewModels
    {
        public IEnumerable<AddAshtrayViewModel> FavoriteAshtray { get; set; }// = new List<AddAshtrayViewModel>();
        public IEnumerable<AddCigarPocketCaseViewModel> FavoriteCigarPoketCase { get; set; }// = new List<AddCigarPocketCaseViewModel>();
        public IEnumerable<AddCigarilloViewModel> FavoriteCigarillo { get; set; }// = new List<AddCigarilloViewModel>();
        public IEnumerable<AddCigarViewModel> FavoriteCigar { get; set; }// = new List<AddCigarViewModel>();
        public IEnumerable<AddCutterViewModel> FavoriteCutter { get; set; }// = new List<AddCutterViewModel>();
        public IEnumerable<AddHumidorViewModel> FavoriteHumidor { get; set; }// = new List<AddHumidorViewModel>();
        public IEnumerable<AddLighterViewModel> FavoriteLighter { get; set; }// = new List<AddLighterViewModel>();
    }
}
