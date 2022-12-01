using CigarWorld.Data.Models.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CigarWorld.Data.Configuration
{
    public class CigarReviewConfiguration : IEntityTypeConfiguration<CigarReview>
    {
        public void Configure(EntityTypeBuilder<CigarReview> builder)
        {
            builder

                .HasData(new CigarReview()
                {
                    Id = 1,
                    Review = "This cigar is perfect for evenings.",
                    CigarId = 1,
                    Commenter = "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138"
                });
        }
    }
}
