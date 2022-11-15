using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Models.Models;
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

        public async Task<IEnumerable<AshtrayViewModel>> GetAllAsync()
        {
            var entities = await context.Ashtrays
                .ToListAsync();

            return entities
                .Select(m => new AshtrayViewModel()
                {
                    Id = m.Id,
                    Brand = m.Brand,
                    CountryOfManufacturing = m.CountryOfManufacturing,
                    ImageUrl = m.ImageUrl,
                    Comment = m.Comment
                });
        }
    }
}
