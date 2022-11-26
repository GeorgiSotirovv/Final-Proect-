using CigarWorld.Data.Models;
using CigarWorld.Models.BaseModels;
using CigarWorld.Models.JustModels;
using System.ComponentModel.DataAnnotations;
using static CigarWorld.Data.DataConstants.Ashtray;

namespace CigarWorld.Views.ViewModels
{
    public class ViewModel
    {
        public class AddAshtrayViewModel
        {
            [Required]
            [StringLength(MaxBrandLenght, MinimumLength = MinBrandLenght)]
            public string Brand { get; set; } = null!;

            [Required]
            [StringLength(MaxCountryOfManufacturingLenght, MinimumLength = MinCountryOfManufacturingLenght)]
            public string CountryOfManufacturing { get; set; } = null!;

            [Required]
            public string ImageUrl { get; set; } = null!;

            [Required]
            [StringLength(MaxCommentLenght, MinimumLength = MinCommentLenght)]
            public string Comment { get; set; } = null!;

            public int TypeId { get; set; }

            public string? AshtrayType { get; set; }

            public IEnumerable<AshtrayType> AshtrayTypes { get; set; } = new List<AshtrayType>();
        }
        public IEnumerable<CigarPocketCaseViewModel> CigarPocketCase { get; set; }
    }
}
