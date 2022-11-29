﻿using CigarWorld.Data.Models.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CigarWorld.Data.Configuration
{
    public class LighterReviewConfiguration : IEntityTypeConfiguration<LighterReview>
    {
        public void Configure(EntityTypeBuilder<LighterReview> builder)
        {
            builder

                .HasData(new LighterReview()
                {
                    Id = 1,
                    Review = "This lighter is different from the rest because the flame is more stronger than the ordinary lighter",
                    LighterId = 1
                });
        }
    }
}
