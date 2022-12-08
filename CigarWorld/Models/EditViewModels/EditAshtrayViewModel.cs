using CigarWorld.Data.Models;
using CigarWorld.Models.EditViewModels;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Ashtray;

namespace CigarWorld.Models.EditViewModels
{
    public class EditAshtrayViewModel : BaseEditViewModel
    {
        public int TypeId { get; set; }

        public IEnumerable<AshtrayType> AshtrayTypes { get; set; } = new List<AshtrayType>();
    }
}
