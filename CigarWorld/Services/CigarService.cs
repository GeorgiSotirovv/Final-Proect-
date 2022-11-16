using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Models.Models;
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

        public async Task<IEnumerable<CigarViewModel>> GetAllAsync()
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
    }
}
