using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CigarWorld.Data.Models
{
    public class User 
    {
        [Required]
        public string ApplicationUserId { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; }


        [Required]
        public int AshtrayId { get; set; }

        [ForeignKey(nameof(AshtrayId))]
        public Ashtray Ashtray { get; set; }


        [Required]
        public int CigarId { get; set; }

        [ForeignKey(nameof(CigarId))]
        public Cigar Cigar { get; set; }


        [Required]
        public int CigarilloId { get; set; }

        [ForeignKey(nameof(CigarilloId))]
        public Cigarillo Cigarillo { get; set; }


        [Required]
        public int CigarPocketCaseId { get; set; }

        [ForeignKey(nameof(CigarPocketCaseId))]
        public CigarPocketCase CigarPocketCase { get; set; }


        [Required]
        public int CutterId { get; set; }

        [ForeignKey(nameof(CutterId))]
        public Cutter Cutter { get; set; }


        [Required]
        public int HumidorId { get; set; }

        [ForeignKey(nameof(HumidorId))]
        public Humidor Humidor { get; set; }


        [Required]
        public int LighterId { get; set; }

        [ForeignKey(nameof(LighterId))]
        public Lighter Lighter { get; set; }
    }
}
