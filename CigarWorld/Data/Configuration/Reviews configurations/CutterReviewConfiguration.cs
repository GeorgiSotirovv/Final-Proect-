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
                    CutterId = 1
                });
        }
    }
}
