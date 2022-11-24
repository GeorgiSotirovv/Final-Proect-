using CigarWorld.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CigarWorld.Data.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(SeedUsers());
        }

        private List<ApplicationUser> SeedUsers()
        {
            var users = new List<ApplicationUser>();
            var hasher = new PasswordHasher<ApplicationUser>();

            var user = new ApplicationUser()
            {
                Id = "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                ProfilePictureUrl = "Empty",
                Introduction = "I am Admin",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM"
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "admin1312");

            users.Add(user);


            user = new ApplicationUser()
            {
                Id = "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                ProfilePictureUrl = "Empty",
                Introduction = "I am guest",
                UserName = "Guest",
                NormalizedUserName = "GUEST",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM"
            };

            user.PasswordHash =
            hasher.HashPassword(user, "guest123");

            users.Add(user);

            return users;
        }
    }
}
