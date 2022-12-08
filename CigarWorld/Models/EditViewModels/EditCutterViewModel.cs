using CigarWorld.Data.Models;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Cutter;

namespace CigarWorld.Models.EditViewModels
{
    public class EditCutterViewModel : BaseEditViewModel
    {

        [Required]
        public int TypeId { get; set; }

        public IEnumerable<CutterType> CutterTypes { get; set; } = new List<CutterType>();
    }
}
