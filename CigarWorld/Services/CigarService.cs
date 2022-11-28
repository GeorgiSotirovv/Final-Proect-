using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Data.Models;
using CigarWorld.Data.Models.ManyToMany;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.Models;
using CigarWorld.Models.MyFavoriteViewModels;
using Microsoft.EntityFrameworkCore;

namespace CigarWorld.Services
{
    public class CigarService : ICigarService
    {
        private readonly CigarWorldDbContext context;

        public CigarService(CigarWorldDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<StrengthType>> GetStrengthTypeAsync()
        {
            return await context.StrengthTypes.ToListAsync();
        }

        public async Task AddCigarsAsync(AddCigarViewModel model)
        {
            var entity = new Cigar()
            {
                Brand = model.Brand,
                CountryOfManufacturing = model.CountryOfManufacturing,
                ImageUrl = model.ImageUrl,
                Comment = model.Comment,
                Format = model.Format,
                Length = model.Length,
                Ring = model.Ring,
                SmokingDuration = model.SmokingDuration,
                StrengthId = model.StrengthId
            };
            await context.Cigars.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CigarViewModel>> GetAllCigarsAsync()
        {
            var entities = await context.Cigars
                .Include(x => x.StrengthType)
                .ToListAsync();

            return entities
                .Select(m => new CigarViewModel()
                {
                    Id = m.Id,
                    Brand = m.Brand,
                    CountryOfManufacturing = m.CountryOfManufacturing,
                    ImageUrl = m.ImageUrl,
                    Comment = m.Comment,
                    Format = m.Format,
                    Strength = m?.StrengthType?.Name,
                    Length = m.Length,
                    Ring = m.Ring,
                    SmokingDuration = m.SmokingDuration,
                });
        }

        public async Task AddFavoriteCigarAsync(int cigarId, string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID.");
            }

            var cigar = await context.Cigars.FirstOrDefaultAsync(a => a.Id == cigarId);

            if (cigar == null)
            {
                throw new ArgumentException("Invalid Cigar ID.");
            }

            if (user.UserCigars.Any(m => m.CigarId == cigarId))
            {
                throw new ArgumentException("This Case is alredy added.");
            }

            if (!user.UserCigars.Any(m => m.CigarId == cigarId))
            {
                user.UserCigars.Add(new UserCigar()
                {
                    CigarId = cigar.Id,
                    UserId = user.Id,
                    Cigar = cigar,
                    ApplicationUser = user
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MyFavoriteCigarViewModel>> GetMineCigarsAsync(string userId)
        {

            var user = await context.Users
              .Where(u => u.Id == userId)
              .Include(u => u.UserCigars)
              .ThenInclude(um => um.Cigar)
              .ThenInclude(m => m.StrengthType)
              .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.UserCigars
                .Select(m => new MyFavoriteCigarViewModel()
                {
                    Brand = m.Cigar.Brand,
                    ImageUrl = m.Cigar.ImageUrl,
                    Comment = m.Cigar.Comment,
                    CountryOfManufacturing = m.Cigar.CountryOfManufacturing,
                    StrengthType = m.Cigar.StrengthType.Name,
                    Format = m?.Cigar.Format,
                    Length = m.Cigar.Length,
                    Ring = m.Cigar.Ring,
                    SmokingDuration = m.Cigar.SmokingDuration,
                });

        }
    }
}
