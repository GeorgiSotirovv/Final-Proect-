using CigarWorld.Data.Models;
using CigarWorld.Models.AddViewModels;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Cutter;

namespace CigarWorld.Models.AddModels
{
    public class AddCutterViewModel : BaseAddViewModel
    {
        [Required]
        public int TypeId { get; set; }

        public IEnumerable<CutterType> CutterTypes { get; set; } = new List<CutterType>();
    }
}
