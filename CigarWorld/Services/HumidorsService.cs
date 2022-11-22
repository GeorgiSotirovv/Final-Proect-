using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Data.Models;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.JustModels;
using Microsoft.EntityFrameworkCore;

namespace CigarWorld.Services
{
    public class HumidorsService : IHumidorsService
    {
        private readonly CigarWorldDbContext context;

        public HumidorsService(CigarWorldDbContext _context)
        {
            context = _context;
        }

        public async Task AddHumidorAsync(AddHumidorViewModel model)
        {
            var entity = new Humidor()
            {
                Brand = model.Brand,
                CountryOfManufacturing = model.CountryOfManufacturing,
                ImageUrl = model.ImageUrl,
                Comment = model.Comment,
                Height = model.Height,
                Length = model.Length,
                Weight = model.Weight,
                MaterialOfManufacture = model.MaterialOfManufacture,
                Capacity = model.Capacity
            };
            await context.Humidors.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HumidorViewModel>> GetAllAsync()
        {
            var entities = await context.Humidors
               .ToListAsync();

            return entities
                .Select(m => new HumidorViewModel()
                {
                    Id = m.Id,
                    Brand = m.Brand,
                    CountryOfManufacturing = m.CountryOfManufacturing,
                    ImageUrl = m.ImageUrl,
                    Comment = m.Comment,
                    Height = m.Height,
                    Length = m.Length,
                    Weight = m.Weight,
                    MaterialOfManufacture = m.MaterialOfManufacture,
                    Capacity = m.Capacity,
                });
        }
    }
}
