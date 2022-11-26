using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Data.Models;
using CigarWorld.Data.Models.ManyToMany;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CigarWorld.Services
{
    public class CigarilloService : ICigarilloService
    {
        private readonly CigarWorldDbContext context;

        public CigarilloService(CigarWorldDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<FilterType>> GetTypesAsync()
        {
            return await context.FilterTypes.ToListAsync();
        }

        public async Task AddCigarilloAsync(AddCigarilloViewModel model)
        {
            var entity = new Cigarillo()
            {
                Brand = model.Brand,
                CountryOfManufacturing = model.CountryOfManufacturing,
                ImageUrl = model.ImageUrl,
                Comment = model.Comment,
                FiterId = model.FiterId
            };
            await context.Cigarillo.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CigarilloViewModel>> GetAllCigarillosAsync()
        {
            var entities = await context.Cigarillo
                .Include(x => x.FilterType)
                .ToListAsync();

            return entities
                .Select(m => new CigarilloViewModel()
                {
                    Id = m.Id,
                    Brand = m.Brand,
                    CountryOfManufacturing = m.CountryOfManufacturing,
                    ImageUrl = m.ImageUrl,
                    Comment = m.Comment,
                    Filter = m?.FilterType?.Name
                });
        }

        public async Task AddFavoriteCigarilloAsync(int cigarilloId, string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new ArgumentException("Invalid user ID.");
            }

            var cigarillo = await context.Cigarillo.FirstOrDefaultAsync(a => a.Id == cigarilloId);
            if (cigarillo == null)
            {
                throw new ArgumentException("Invalid Cigarillo ID.");
            }

            if (user.UserCigarPocketCases.Any(m => m.CigarPocketCaseId == cigarilloId))
            {
                throw new ArgumentException("This Case is alredy added.");
            }

            if (!user.UserCigarPocketCases.Any(m => m.CigarPocketCaseId == cigarilloId))
            {
                user.UserCigarillos.Add(new UserCigarillo()
                {
                    CigarilloId = cigarillo.Id,
                    UserId = user.Id,
                    Cigarillo = cigarillo,
                    ApplicationUser = user
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AddCigarilloViewModel>> GetMineCigarillosAsync(string userId)
        {
            var user = await context.Users
              .Where(u => u.Id == userId)
              .Include(u => u.UserCigarillos)
              .ThenInclude(um => um.Cigarillo)
              .ThenInclude(m => m.FilterType)
              .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.UserCigarillos
                .Select(m => new AddCigarilloViewModel()
                {
                    Brand = m.Cigarillo.Brand,
                    ImageUrl = m.Cigarillo.ImageUrl,
                    Comment = m.Cigarillo.Comment,
                    CountryOfManufacturing = m.Cigarillo.CountryOfManufacturing,
                    FilterType = m.Cigarillo.FilterType.Id
                });
        }
    }
}
