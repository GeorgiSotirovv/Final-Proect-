using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Data.Models;
using CigarWorld.Data.Models.ManyToMany;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.JustModels;
using CigarWorld.Models.MyFavoriteViewModels;
using Microsoft.EntityFrameworkCore;

namespace CigarWorld.Services
{
    public class HumidorService : IHumidorsService
    {
        private readonly CigarWorldDbContext context;

        public HumidorService(CigarWorldDbContext _context)
        {
            context = _context;
        }

        public async Task AddFavoriteHumidorAsync(int humidorId, string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID.");
            }

            var humidor = await context.Humidors.FirstOrDefaultAsync(a => a.Id == humidorId);

            if (humidor == null)
            {
                throw new ArgumentException("Invalid Humidor ID.");
            }

            if (user.UserHumidors.Any(m => m.HumidorId == humidorId))
            {
                throw new ArgumentException("This Humidor is alredy added.");
            }

            if (!user.UserHumidors.Any(m => m.HumidorId == humidorId))
            {
                user.UserHumidors.Add(new UserHumidor()
                {
                    HumidorId = humidor.Id,
                    UserId = user.Id,
                    Humidor = humidor,
                    ApplicationUser = user
                });

                await context.SaveChangesAsync();
            }
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

        public async Task<IEnumerable<MyFavoriteHomidorViewModel>> GetMineHumidorsAsync(string userId)
        {
            var user = await context.Users
              .Where(u => u.Id == userId)
              .Include(u => u.UserHumidors)
              .ThenInclude(um => um.Humidor)
              .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.UserHumidors
                .Select(m => new MyFavoriteHomidorViewModel()
                {
                    Brand = m.Humidor.Brand,
                    Height = m.Humidor.Height,
                    Length = m.Humidor.Length,
                    Weight = m.Humidor.Weight,
                    ImageUrl = m.Humidor.ImageUrl,
                    Comment = m.Humidor.Comment,
                    CountryOfManufacturing = m.Humidor.CountryOfManufacturing,
                    Capacity = m.Humidor.Capacity,
                    MaterialOfManufacture = m.Humidor.MaterialOfManufacture
                });
        }
    }
}
