using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CigarWorld.Data.DataConstants.Cutter;

namespace CigarWorld.Data.Models
{
    public class Cutter
    {
        [Key]
        public int Id { get; set; }


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

        [ForeignKey(nameof(TypeId))]
        public CutterType? CutterType { get; set; }
    }
}
