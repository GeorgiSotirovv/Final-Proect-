using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Data.Models;
using CigarWorld.Models.AddModels;
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

        public async Task<IEnumerable<StrengthType>> GetStrengthTypeAsync()
        {
            return await context.StrengthTypes.ToListAsync();
        }

        public async Task AddCigarsAsync(AddCigarViewModel model)
        {
            var entity = new Cigar()
            {
                Brand = model.Brand,
                CountryOfManufacturing = model.CountryOfManufacturing,
                ImageUrl = model.ImageUrl,
                Comment = model.Comment,
                Format = model.Format,
                Length = model.Length,
                Ring = model.Ring,
                SmokingDuration = model.SmokingDuration,
                StrengthId = model.StrengthId
            };
            await context.Cigars.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CigarViewModel>> GetAllCigarsAsync()
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
