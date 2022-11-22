using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Data.Models;
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
            await context.Cigarillos.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CigarilloViewModel>> GetAllCigarillosAsync()
        {
            var entities = await context.Cigarillos
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

    }
}
