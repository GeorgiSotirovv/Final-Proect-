using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Models.JustModels;
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
        public async Task<IEnumerable<LighterViewModel>> GetAllAsync()
        {
            var entities = await context.Lighters
               .ToListAsync();

            return entities
                .Select(m => new LighterViewModel()
                {
                    Id = m.Id,
                    Brand = m.Brand,
                    CountryOfManufacturing = m.CountryOfManufacturing,
                    ImageUrl = m.ImageUrl,
                    Comment = m.Comment,
                });
        }
    }
}
