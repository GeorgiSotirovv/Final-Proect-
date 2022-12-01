using CigarWorld.Data.Models.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CigarWorld.Data.Configuration
{
    public class AshtrayReviewConfiguration : IEntityTypeConfiguration<AshtrayReview>
    {
        public void Configure(EntityTypeBuilder<AshtrayReview> builder)
        {
            builder

                .HasData(new AshtrayReview()
                {
                    Id = 1,
                    Review = "Very nice and colorfull ashtray.",
                    AshtrayId = 1,
                    Commenter = "Admin"
                });
        }
    }
}
