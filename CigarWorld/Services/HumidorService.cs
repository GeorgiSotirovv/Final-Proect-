using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Data.Models;
using CigarWorld.Data.Models.ManyToMany;
using CigarWorld.Data.Models.Reviews;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
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

        public async Task<IEnumerable<AllHumidorViewModel>> GetAllAsync()
        {
            var entities = await context.Humidors
               .ToListAsync();

            return entities
                .Select(m => new AllHumidorViewModel()
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

        public async Task RemoveFromFavoritesAsync(int humidorId, string userId)
        {
            var user = await context.Users
              .Where(u => u.Id == userId)
              .Include(u => u.UserHumidors)
              .ThenInclude(um => um.Humidor)
              .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user Id");
            }

            var ashtray = user.UserHumidors.FirstOrDefault(m => m.HumidorId == humidorId);

            if (ashtray != null)
            {
                user.UserHumidors.Remove(ashtray);

                await context.SaveChangesAsync();
            }
        }

        public async Task<HumidorDetailsViewModel> GetDetailsAsync(int humidorId, string userName)
        {
            var humidor = await context.Humidors
              .Where(u => u.Id == humidorId)
              .Include(m => m.HumidorReviews)
              .FirstOrDefaultAsync();

            if (humidor == null)
            {
                throw new ArgumentException("Invalid humidor ID");
            }

            return new HumidorDetailsViewModel()
            {
                Brand = humidor.Brand,
                CountryOfManufacturing = humidor.CountryOfManufacturing,
                ImageUrl = humidor.ImageUrl,
                Comment = humidor.Comment,
                Height=humidor.Height,
                Weight = humidor.Weight,
                Length = humidor.Length,
                MaterialOfManufacture = humidor.MaterialOfManufacture,
                Capacity=humidor.Capacity,
                HumidorReviews = humidor.HumidorReviews,
                UserName = userName
            };
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
                    Id = m.HumidorId,
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

        public async Task RemoveFromCollectionAsync(int humidorId, string userId)
        {
            var user = await context.Users
               .Where(u => u.Id == userId)
               .Include(u => u.UserHumidors)
               .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var book = user.UserHumidors.FirstOrDefault(m => m.HumidorId == humidorId);

            if (book != null)
            {
                user.UserHumidors.Remove(book);

                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveFromDatabaseAsync(int humidorId)
        {

            var humidor = await context.Humidors
                .Where(u => u.Id == humidorId)
                .FirstOrDefaultAsync();


            if (humidor == null)
            {
                throw new ArgumentException("Invalid Humidor Id");
            }

            context.Humidors.Remove(humidor);

            await context.SaveChangesAsync();

        }

        public async Task EditHumidor(int humidorId)
        {
            var humidor = await context.Humidors
               .Where(u => u.Id == humidorId)
               .FirstOrDefaultAsync();
        }

        public async Task<EditHumidorViewModel> GetInformationForHumidor(int humidorId)
        {
            var humidor = await context.Humidors
                .Where(u => u.Id == humidorId)
                .FirstOrDefaultAsync();


            var result = new EditHumidorViewModel
            {
                Id = humidor.Id,
                Brand = humidor.Brand,
                Comment = humidor.Comment,
                CountryOfManufacturing = humidor.CountryOfManufacturing,
                ImageUrl = humidor.ImageUrl,
                Height = humidor.Height,
                Length = humidor.Length,
                Weight = humidor.Weight,
                Capacity = humidor.Capacity,
                MaterialOfManufacture = humidor.MaterialOfManufacture
            };

            return result;
        }

        public async void EditHumidorInformation(EditHumidorViewModel targetHumidor)
        {
            var humidor = context.Humidors.
               Where(u => u.Id == targetHumidor.Id)
               .FirstOrDefault();

            if (humidor == null)
            {
                throw new ArgumentException("Invalid Humidor");
            }

            humidor.Brand = targetHumidor.Brand;
            humidor.CountryOfManufacturing = targetHumidor.CountryOfManufacturing;
            humidor.ImageUrl = targetHumidor.ImageUrl;
            humidor.Comment = targetHumidor.Comment;
            humidor.MaterialOfManufacture = targetHumidor.MaterialOfManufacture;
            humidor.Capacity = targetHumidor.Capacity;
            humidor.Height = targetHumidor.Height;
            humidor.Length = targetHumidor.Length;
            humidor.Weight = targetHumidor.Weight;

            context.SaveChanges();
        }

        public HumidorDetailsViewModel AddReview(HumidorDetailsViewModel targetHumidor, string UserName)
        {
            var entity = new HumidorReview()
            {
                HumidorId = targetHumidor.Id,
                Review = targetHumidor.AddReviewToHumidor,
                Commenter = UserName
            };

            context.HumidorReviews.Add(entity);
            context.SaveChanges();

            targetHumidor.AddReviewToHumidor = String.Empty;

            return targetHumidor;
        }

        public int DeleteReview(int reviewId)
        {
            var targetReview = context.HumidorReviews
               .Where(x => x.Id == reviewId)
               .FirstOrDefault();

            var targetHumidorId = targetReview.HumidorId;

            context.HumidorReviews.Remove(targetReview);
            context.SaveChanges();
            return (targetHumidorId);
        }

        public int EditReview(int humidorId, string changedReview)
        {
            var targetReview = context.HumidorReviews
               .Where(x => x.Id == humidorId)
               .FirstOrDefault();

            var targetHumidorId = targetReview.HumidorId;

            targetReview.Review = changedReview;

            context.SaveChanges();
            return (targetHumidorId);
        }
    }
}
