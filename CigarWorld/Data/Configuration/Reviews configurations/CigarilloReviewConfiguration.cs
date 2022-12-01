using CigarWorld.Data.Models.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CigarWorld.Data.Configuration
{
    public class CigarilloReviewConfiguration : IEntityTypeConfiguration<CigarilloReview>
    {
        public void Configure(EntityTypeBuilder<CigarilloReview> builder)
        {
            builder

                .HasData(new CigarilloReview()
                {
                    Id = 1,
                    Review = "This Cigarillos are very good.",
                    CigarilloId = 1,
                    Commenter = "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138"
                });
        }
    }
}
