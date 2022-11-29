using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Data.Models;
using CigarWorld.Data.Models.ManyToMany;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.JustModels;
using CigarWorld.Models.MyFavoriteViewModels;
using Microsoft.EntityFrameworkCore;

namespace CigarWorld.Services
{
    public class LighterService : ILighterService
    {
        private readonly CigarWorldDbContext context;

        public LighterService(CigarWorldDbContext _context)
        {
            context = _context;
        }

        public async Task AddFavoriteLighterAsync(int lighterId, string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID.");
            }

            var lighter = await context.Lighters.FirstOrDefaultAsync(a => a.Id == lighterId);

            if (lighter == null)
            {
                throw new ArgumentException("Invalid Lighter ID.");
            }

            if (user.UserLighter.Any(m => m.LighterId == lighterId))
            {
                throw new ArgumentException("This Lighter is alredy added.");
            }

            if (!user.UserCigars.Any(m => m.CigarId == lighterId))
            {
                user.UserLighter.Add(new UserLighter()
                {
                    LighterId = lighter.Id,
                    UserId = user.Id,
                    Lighter = lighter,
                    ApplicationUser = user
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task AddLighterAsync(AddLighterViewModel model)
        {
            var entity = new Lighter()
            {
                Brand = model.Brand,
                CountryOfManufacturing = model.CountryOfManufacturing,
                Comment = model.Comment,
                ImageUrl = model.ImageUrl,
            };

            await context.Lighters.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllLighterViewModel>> GetAllAsync()
        {
            var entities = await context.Lighters
               .ToListAsync();

            return entities
                .Select(m => new AllLighterViewModel()
                {
                    Id = m.Id,
                    Brand = m.Brand,
                    CountryOfManufacturing = m.CountryOfManufacturing,
                    ImageUrl = m.ImageUrl,
                    Comment = m.Comment,
                });
        }

        public async Task<IEnumerable<MyFavoriteLighterViewModel>> GetMineLightersAsync(string userId)
        {
            var user = await context.Users
               .Where(u => u.Id == userId)
               .Include(u => u.UserLighter)
               .ThenInclude(um => um.Lighter)
               .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.UserLighter
                .Select(m => new MyFavoriteLighterViewModel()
                {
                    Brand = m.Lighter.Brand,
                    ImageUrl = m.Lighter.ImageUrl,
                    Comment = m.Lighter.Comment,
                    CountryOfManufacturing = m.Lighter.CountryOfManufacturing,
                });
        }

        public async Task<LighterDetailsViewModel> GetDetailsAsync(int lighterId) 
        {
            var lighter = await context.Lighters
              .Where(u => u.Id == lighterId)
              .FirstOrDefaultAsync();

            if (lighter == null)
            {
                throw new ArgumentException("Invalid humidor ID");
            }

            return new LighterDetailsViewModel()
            {
                Brand = lighter.Brand,
                CountryOfManufacturing = lighter.CountryOfManufacturing,
                ImageUrl = lighter.ImageUrl,
                Comment = lighter.Comment,
                LighterReviews = lighter.LighterReviews
            };
        }
    }
}
