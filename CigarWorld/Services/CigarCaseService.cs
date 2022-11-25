using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Data.Models;
using CigarWorld.Data.Models.ManyToMany;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.JustModels;
using CigarWorld.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CigarWorld.Services
{
    public class CigarCaseService : ICigarCaseService
    {
        private readonly CigarWorldDbContext context;

        public CigarCaseService(CigarWorldDbContext _context)
        {
            context = _context;
        }

        public async Task AddCigarCasesAsync(AddCigarPocketCaseViewModel model)
        {
            var entity = new CigarPocketCase()
            {
                Brand = model.Brand,
                CountryOfManufacturing = model.CountryOfManufacturing,
                ImageUrl = model.ImageUrl,
                Comment = model.Comment,
                Capacity = model.Capacity,
                MaterialOfManufacture = model.MaterialOfManufacture
            };
            await context.CigarPocketCases.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task AddCigarCaseToFavoritesAsync(int cigarPocketCaseId, string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new ArgumentException("Invalid user ID.");
            }

            var cigarPocketCase = await context.CigarPocketCases.FirstOrDefaultAsync(a => a.Id == cigarPocketCaseId);
            if (cigarPocketCase == null)
            {
                throw new ArgumentException("Invalid Case ID.");
            }

            if (user.UserCigarPocketCases.Any(m => m.CigarPocketCaseId == cigarPocketCaseId))
            {
                throw new ArgumentException("This Case is alredy added.");
            }

            if (!user.UserCigarPocketCases.Any(m => m.CigarPocketCaseId == cigarPocketCaseId))
            {
                user.UserCigarPocketCases.Add(new UserCigarPocketCase()
                {
                    CigarPocketCaseId = cigarPocketCase.Id,
                    UserId = user.Id,
                    CigarPocketCase = cigarPocketCase,
                    ApplicationUser = user
                });

                await context.SaveChangesAsync();
            }
        }


        public async Task<IEnumerable<CigarPocketCaseViewModel>> GetAllAsyncCigarCase()
        {
            var entities = await context.CigarPocketCases
                .ToListAsync();

            return entities
                .Select(m => new CigarPocketCaseViewModel()
                {
                    Id = m.Id,
                    Brand = m.Brand,
                    CountryOfManufacturing = m.CountryOfManufacturing,
                    ImageUrl = m.ImageUrl,
                    Comment = m.Comment,
                    Capacity = m.Capacity,
                    MaterialOfManufacture = m.MaterialOfManufacture
                });
        }
    }
}
