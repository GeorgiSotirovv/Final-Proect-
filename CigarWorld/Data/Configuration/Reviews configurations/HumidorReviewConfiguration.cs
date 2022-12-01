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
                    HumidorId = 1,
                    Commenter = "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138"
                });
        }
    }
}
