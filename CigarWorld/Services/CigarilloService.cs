using CigarWorld.Contracts;
using CigarWorld.Data;
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

        public async Task<IEnumerable<CigarilloViewModel>> GetAllAsync()
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
