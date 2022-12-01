using CigarWorld.Data.Models.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CigarWorld.Data.Configuration
{
    public class CigarPocketCaseReviewConfiguration : IEntityTypeConfiguration<CigarPocketCaseReview>
    {
        public void Configure(EntityTypeBuilder<CigarPocketCaseReview> builder)
        {
            builder

                .HasData(new CigarPocketCaseReview()
                {
                    Id = 1,
                    Review = " The Crafting is very good.",
                    CigarPocketCaseId = 1,
                    Commenter = "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138"
                });
        }
    }
}
