using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Data.Models;
using CigarWorld.Models.AddModels;
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

        public async Task AddLighterAsync(AddLighterViewModel model)
        {
            var entity = new Lighter() 
            {
                Brand = model.Brand,
                CountryOfManufacturing = model.CountryOfManufacturing,
                Comment = model.Comment,
                ImageUrl = model.ImageUrl,
            };

            await context.Lighters.AddAsync(entity);
            await context.SaveChangesAsync();
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
