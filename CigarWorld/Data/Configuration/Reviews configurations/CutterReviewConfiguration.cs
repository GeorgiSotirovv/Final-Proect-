using CigarWorld.Data.Models.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CigarWorld.Data.Configuration
{
    public class CutterReviewConfiguration : IEntityTypeConfiguration<CutterReview>
    {
        public void Configure(EntityTypeBuilder<CutterReview> builder)
        {
            builder

                .HasData(new CutterReview()
                {
                    Id = 1,
                    Review = "This is very nice and sharp cutter.",
                    CutterId = 1,
                    Commenter = "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138"
                });
        }
    }
}
