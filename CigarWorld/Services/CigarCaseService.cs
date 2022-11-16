using CigarWorld.Contracts;
using CigarWorld.Data;
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

        public async Task<IEnumerable<CigarPocketCaseViewModel>> GetAllAsync()
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
