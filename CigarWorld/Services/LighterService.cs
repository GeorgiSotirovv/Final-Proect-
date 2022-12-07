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
    public class LighterService : ILighterService
    {
        private readonly CigarWorldDbContext context;

        public LighterService(CigarWorldDbContext _context)
        {
            context = _context;
        }

        public async Task AddFavoriteLighterAsync(int lighterId, string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID.");
            }

            var lighter = await context.Lighters.FirstOrDefaultAsync(a => a.Id == lighterId);

            if (lighter == null)
            {
                throw new ArgumentException("Invalid Lighter ID.");
            }

            if (user.UserLighter.Any(m => m.LighterId == lighterId))
            {
                throw new ArgumentException("This Lighter is alredy added.");
            }

            if (!user.UserLighter.Any(m => m.LighterId == lighterId))
            {
                user.UserLighter.Add(new UserLighter()
                {
                    LighterId = lighter.Id,
                    UserId = user.Id,
                    Lighter = lighter,
                    ApplicationUser = user
                });

                await context.SaveChangesAsync();
            }
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

        public async Task<IEnumerable<AllLighterViewModel>> GetAllAsync()
        {
            var entities = await context.Lighters
               .ToListAsync();

            return entities
                .Select(m => new AllLighterViewModel()
                {
                    Id = m.Id,
                    Brand = m.Brand,
                    CountryOfManufacturing = m.CountryOfManufacturing,
                    ImageUrl = m.ImageUrl,
                    Comment = m.Comment,
                });
        }

        public async Task<IEnumerable<MyFavoriteLighterViewModel>> GetMineLightersAsync(string userId)
        {
            var user = await context.Users
               .Where(u => u.Id == userId)
               .Include(u => u.UserLighter)
               .ThenInclude(um => um.Lighter)
               .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.UserLighter
                .Select(m => new MyFavoriteLighterViewModel()
                {
                    Id = m.LighterId,
                    Brand = m.Lighter.Brand,
                    ImageUrl = m.Lighter.ImageUrl,
                    Comment = m.Lighter.Comment,
                    CountryOfManufacturing = m.Lighter.CountryOfManufacturing,
                });
        }

        public async Task<LighterDetailsViewModel> GetDetailsAsync(int lighterId, string userName)
        {
            var lighter = await context.Lighters
              .Where(u => u.Id == lighterId)
              .Include(u => u.LighterReviews)
              .FirstOrDefaultAsync();

            if (lighter == null)
            {
                throw new ArgumentException("Invalid Lighter Id");
            }

            return new LighterDetailsViewModel()
            {
                Brand = lighter.Brand,
                CountryOfManufacturing = lighter.CountryOfManufacturing,
                ImageUrl = lighter.ImageUrl,
                Comment = lighter.Comment,
                LighterReviews = lighter.LighterReviews,
                UserName = userName
            };
        }

        public async Task RemoveFromFavoritesAsync(int lighterId, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UserLighter)
                .ThenInclude(um => um.Lighter)
                .FirstOrDefaultAsync();


            if (user == null)
            {
                throw new ArgumentException("Invalid user Id");
            }

            var lighter = user.UserLighter.FirstOrDefault(m => m.LighterId == lighterId);


            if (lighter != null)
            {
                user.UserLighter.Remove(lighter);

                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveFromDatabaseAsync(int lighterId)
        {
            var lighter = await context.Lighters
                .Where(u => u.Id == lighterId)
                .FirstOrDefaultAsync();


            if (lighter == null)
            {
                throw new ArgumentException("Invalid Lighter Id");
            }

            context.Lighters.Remove(lighter);

            await context.SaveChangesAsync();

        }

        public async Task EditLighter(int lighterId)
        {
            var ashtray = await context.Lighters
                 .Where(u => u.Id == lighterId)
                 .FirstOrDefaultAsync();
        }

        public async Task<EditLighterViewModel> GetInformationForLighter(int lighterId)
        {
            var lighter = await context.Lighters
                .Where(u => u.Id == lighterId)
                .FirstOrDefaultAsync();


            var result = new EditLighterViewModel
            {
                Id = lighter.Id,
                Brand = lighter.Brand,
                Comment = lighter.Comment,
                CountryOfManufacturing = lighter.CountryOfManufacturing,
                ImageUrl = lighter.ImageUrl
            };

            return result;
        }

        public void EditLighterInformation(EditLighterViewModel targetLighter)
        {
            var ashtray = context.Lighters.
                Where(u => u.Id == targetLighter.Id)
                .FirstOrDefault();

            if (ashtray == null)
            {
                throw new ArgumentException("Invalid Lighter");
            }

            ashtray.Brand = targetLighter.Brand;
            ashtray.CountryOfManufacturing = targetLighter.CountryOfManufacturing;
            ashtray.ImageUrl = targetLighter.ImageUrl;
            ashtray.Comment = targetLighter.Comment;

            context.SaveChanges();
        }

        public LighterDetailsViewModel AddReview(LighterDetailsViewModel targetLighter, string UserName)
        {
            var entity = new LighterReview()
            {
                LighterId = targetLighter.Id,
                Review = targetLighter.AddReviewToLighter,
                Commenter = UserName
            };

            context.LighterReviews.Add(entity);
            context.SaveChanges();

            targetLighter.AddReviewToLighter = String.Empty;

            return targetLighter;
        }

        public int DeleteReview(int reviewId)
        {
            var targetReview = context.LighterReviews
                .Where(x => x.Id == reviewId)
                .FirstOrDefault();

            var targetLeghterId = targetReview.LighterId;

            context.LighterReviews.Remove(targetReview);
            context.SaveChanges();
            return (targetLeghterId);
        }

        public int EditReview(int lighterId, string changedReview)
        {
            var targetReview = context.LighterReviews
               .Where(x => x.Id == lighterId)
               .FirstOrDefault();

            var targetLighterId = targetReview.LighterId;

            targetReview.Review = changedReview;

            context.SaveChanges();
            return (targetLighterId);
        }
    }
}
