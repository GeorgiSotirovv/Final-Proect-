using CigarWorld.Data.Models.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CigarWorld.Data.Configuration
{
    public class HumidorReviewConfiguration : IEntityTypeConfiguration<HumidorReview>
    {
        public void Configure(EntityTypeBuilder<HumidorReview> builder)
        {
            builder

                .HasData(new HumidorReview()
                {
                    Id = 1,
                    Review = "Very solid humidor with good crafting.",
                    HumidorId = 1
                });
        }
    }
}
