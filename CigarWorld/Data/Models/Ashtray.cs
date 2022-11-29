using CigarWorld.Data.Models.Reviews;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CigarWorld.Data.DataConstants.Ashtray;

namespace CigarWorld.Data.Models
{
    public class Ashtray
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

        [Required]
        public int AshtrayId { get; set; }

        [ForeignKey(nameof(AshtrayId))]

        public AshtrayType? AshtrayType { get; set; }

        public IEnumerable<AshtrayReview> AshtrayReviews { get; set; } = new List<AshtrayReview>();
    }
}
