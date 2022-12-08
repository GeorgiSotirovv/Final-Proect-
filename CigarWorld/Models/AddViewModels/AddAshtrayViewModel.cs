using CigarWorld.Data.Models;
using CigarWorld.Models.AddViewModels;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Ashtray;

namespace CigarWorld.Models.AddModels
{
    public class AddAshtrayViewModel : BaseAddViewModel
    {
        public int TypeId { get; set; }

        public IEnumerable<AshtrayType> AshtrayTypes { get; set; } = new List<AshtrayType>();
    }
}
