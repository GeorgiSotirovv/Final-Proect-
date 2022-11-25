using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Data.Models;
using CigarWorld.Data.Models.ManyToMany;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.BaseModels;
using Microsoft.EntityFrameworkCore;

namespace CigarWorld.Services
{
    public class AshtrayService : IAshtrayService
    {
        private readonly CigarWorldDbContext context;

        public AshtrayService(CigarWorldDbContext _context)
        {
            context = _context;
        }


        public async Task AddAshtraysAsync(AddAshtrayViewModel model)
        {
            var entity = new Ashtray()
            {
                Brand = model.Brand,
                CountryOfManufacturing = model.CountryOfManufacturing,
                ImageUrl = model.ImageUrl,
                Comment = model.Comment,
                AshtrayId = model.TypeId
            };
            await context.Ashtrays.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task AddAshtrayToFavoritesAsync(int ashtrayId, string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var ashtray = await context.Ashtrays.FirstOrDefaultAsync(u => u.Id == ashtrayId);

            if (ashtray == null)
            {
                throw new ArgumentException("Invalid Ashtray ID");
            }
            if (user.UserAshtrays.Any(m => m.AshtrayId == ashtrayId))
            {
                throw new ArgumentException("Ashtray all added");
            }

            if (!user.UserAshtrays.Any(m => m.AshtrayId == ashtrayId))
            {
                user.UserAshtrays.Add(new UserAshtray()
                {
                    AshtrayId = ashtray.Id,
                    UserId = user.Id,
                    Ashtray = ashtray,
                    ApplicationUser = user
                });

                await context.SaveChangesAsync();
            }
        }


        public async Task<IEnumerable<AshtrayViewModel>> GetAllAshtrayAsync()
        {
            var entities = await context.Ashtrays
                .Include(x => x.AshtrayType)
                .ToListAsync();

            return entities
                .Select(m => new AshtrayViewModel()
                {
                    Id = m.Id,
                    Brand = m.Brand,
                    CountryOfManufacturing = m.CountryOfManufacturing,
                    ImageUrl = m.ImageUrl,
                    Comment = m.Comment,
                    Type = m?.AshtrayType?.Name
                });
        }

        public async Task<IEnumerable<AshtrayType>> GetTypesAsync()
        {
            return await context.AshtrayTypes.ToListAsync();
        }
    }
}
