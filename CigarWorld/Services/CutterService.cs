using CigarWorld.Contracts;
using CigarWorld.Data;
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

        public async Task<IEnumerable<CutterViewModel>> GetAllAsync()
        {
            var entities = await context.Cutters
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
    }
}
