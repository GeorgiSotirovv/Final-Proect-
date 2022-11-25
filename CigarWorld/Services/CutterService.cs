using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Data.Models;
using CigarWorld.Data.Models.ManyToMany;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CigarWorld.Services
{
    public class CutterService : ICutterService
    {
        private readonly CigarWorldDbContext context;

        public CutterService(CigarWorldDbContext _context)
        {
            context = _context;
        }


        public async Task<IEnumerable<CutterType>> GetTypesAsync()
        {
            return await context.CutterTypes.ToListAsync();
        }

        public async Task AddCutterAsync(AddCutterViewModel model)
        {
            var entity = new Cutter()
            {
                Brand = model.Brand,
                CountryOfManufacturing = model.CountryOfManufacturing,
                ImageUrl = model.ImageUrl,
                Comment = model.Comment,
                TypeId = model.TypeId
            };
            await context.Cutters.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CutterViewModel>> GetAllAsync()
        {
            var entities = await context.Cutters
                .Include(x => x.CutterType)
                .ToListAsync();

            return entities
                .Select(m => new CutterViewModel()
                {
                    Id = m.Id,
                    Brand = m.Brand,
                    CountryOfManufacturing = m.CountryOfManufacturing,
                    ImageUrl = m.ImageUrl,
                    Comment = m.Comment,
                    Type = m?.CutterType?.Name

                });
        }

        public async Task AddFavoriteCutterAsync(int cutterId, string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID.");
            }

            var cigar = await context.Cutters.FirstOrDefaultAsync(a => a.Id == cutterId);

            if (cigar == null)
            {
                throw new ArgumentException("Invalid Cutter ID.");
            }

            if (user.UserCutters.Any(m => m.CutterId == cutterId))
            {
                throw new ArgumentException("This Cutter is alredy added.");
            }

            if (!user.UserCutters.Any(m => m.CutterId == cutterId))
            {
                user.UserCutters.Add(new UserCutter()
                {
                    CutterId = cigar.Id,
                    UserId = user.Id,
                    Cutter = cigar,
                    ApplicationUser = user
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
