using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Data.Models;
using CigarWorld.Data.Models.ManyToMany;
using CigarWorld.Data.Models.Reviews;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using CigarWorld.Models.Models;
using CigarWorld.Models.MyFavoriteViewModels;
using Microsoft.EntityFrameworkCore;

namespace CigarWorld.Services
{
    public class CigarilloService : ICigarilloService
    {
        private readonly CigarWorldDbContext context;

        public CigarilloService(CigarWorldDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<FilterType>> GetTypesAsync()
        {
            return await context.FilterTypes.ToListAsync();
        }

        public async Task AddCigarilloAsync(AddCigarilloViewModel model)
        {
            var entity = new Cigarillo()
            {
                Brand = model.Brand,
                CountryOfManufacturing = model.CountryOfManufacturing,
                ImageUrl = model.ImageUrl,
                Comment = model.Comment,
                FiterId = model.FiterId
            };
            await context.Cigarillo.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllCigarilloViewModel>> GetAllCigarillosAsync(string userId)
        {
            var favorites = await context.UserCigarillos
                .Include(x => x.Cigarillo)
                .ThenInclude(x => x.FilterType)
                .Where(x => x.UserId == userId)
                .ToListAsync();

            var ashtray = await context.Cigarillo
                .Include(x => x.FilterType)
                .ToListAsync();

            return ashtray
                .Select(m => new AllCigarilloViewModel()
                {
                    Id = m.Id,
                    Brand = m.Brand,
                    CountryOfManufacturing = m.CountryOfManufacturing,
                    ImageUrl = m.ImageUrl,
                    Comment = m.Comment,
                    Filter = m?.FilterType?.Name,
                    IsFavorite = favorites.Where(x => x.CigarilloId == m.Id).Count() > 0
                });
        }

        public async Task AddFavoriteCigarilloAsync(int cigarilloId, string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new ArgumentException("Invalid user ID.");
            }

            var cigarillo = await context.Cigarillo.FirstOrDefaultAsync(a => a.Id == cigarilloId);
            if (cigarillo == null)
            {
                throw new ArgumentException("Invalid Cigarillo ID.");
            }

            if (user.UserCigarPocketCases.Any(m => m.CigarPocketCaseId == cigarilloId))
            {
                throw new ArgumentException("This Cigarillo is alredy added.");
            }

            if (!user.UserCigarillos.Any(m => m.Cigarillo.Id == cigarilloId))
            {
                user.UserCigarillos.Add(new UserCigarillo()
                {
                    CigarilloId = cigarillo.Id,
                    UserId = user.Id,
                    Cigarillo = cigarillo,
                    ApplicationUser = user
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MyFavoriteCigarilloViewModel>> GetMineCigarillosAsync(string userId)
        {
            var user = await context.Users
              .Where(u => u.Id == userId)
              .Include(u => u.UserCigarillos)
              .ThenInclude(um => um.Cigarillo)
              .ThenInclude(m => m.FilterType)
              .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.UserCigarillos
                .Select(m => new MyFavoriteCigarilloViewModel()
                {
                    Id = m.CigarilloId,
                    Brand = m.Cigarillo.Brand,
                    ImageUrl = m.Cigarillo.ImageUrl,
                    Comment = m.Cigarillo.Comment,
                    CountryOfManufacturing = m.Cigarillo.CountryOfManufacturing,
                    FilterType = m.Cigarillo.FilterType.Name
                });
        }

        public async Task RemoveFromFavoritesAsync(int cigarilloId, string userId)
        {
            var targetUserCigarillo = context.UserCigarillos
               .Where(x => x.CigarilloId == cigarilloId)
               .Where(x => x.UserId == userId)
               .FirstOrDefault();

            if (targetUserCigarillo == null)
            {
                throw new ArgumentException("Invalid user Id");
            }

            context.UserCigarillos.Remove(targetUserCigarillo);

            await context.SaveChangesAsync();
        }

        public async Task<CigarilloDetailsViewModel> GetDetailsAsync(int cigarilloId, string userName)
        {
            var cigarillo = await context.Cigarillo
              .Where(u => u.Id == cigarilloId)
              .Include(m => m.CigarilloReviews)
              .Include(m => m.FilterType)
              .FirstOrDefaultAsync();

            if (cigarillo == null)
            {
                throw new ArgumentException("Invalid Cigarillo Id");
            }

            return new CigarilloDetailsViewModel()
            {
                Brand = cigarillo.Brand,
                CountryOfManufacturing = cigarillo.CountryOfManufacturing,
                ImageUrl = cigarillo.ImageUrl,
                Comment = cigarillo.Comment,
                Filter = cigarillo?.FilterType?.Name,
                CigarilloReviews = cigarillo.CigarilloReviews,
                UserName = userName
            };
        }


        public async Task RemoveFromDatabaseAsync(int cigarilloId)
        {

            var cigarillo = await context.Cigarillo
                .Where(u => u.Id == cigarilloId)
                .FirstOrDefaultAsync();


            if (cigarillo == null)
            {
                throw new ArgumentException("Invalid Cigarillo Id");
            }

            context.Cigarillo.Remove(cigarillo);

            await context.SaveChangesAsync();

        }

        public async Task EditCigarillo(int cigarilloId)
        {
            var cigarillo = await context.Cigarillo
                .Where(u => u.Id == cigarilloId)
                .FirstOrDefaultAsync();
        }

        public async Task<EditCigarilloViewModel> GetInformationForCigarillo(int cigarilloId)
        {
            var cigarillo = await context.Cigarillo
                .Where(u => u.Id == cigarilloId)
                .FirstOrDefaultAsync();


            var result = new EditCigarilloViewModel
            {
                Id = cigarillo.Id,
                Brand = cigarillo.Brand,
                Comment = cigarillo.Comment,
                CountryOfManufacturing = cigarillo.CountryOfManufacturing,
                ImageUrl = cigarillo.ImageUrl,
                FiterId = cigarillo.FiterId,
                FilterTypes = this.GetTypesAsync().Result
            };

            return result;
        }

        public void EditCigarilloInformation(EditCigarilloViewModel targetCigarillo)
        {
            var ashtray = context.Cigarillo.
                Where(u => u.Id == targetCigarillo.Id)
                .FirstOrDefault();

            if (ashtray == null)
            {
                throw new ArgumentException("Invalid Cigarillo");
            }

            ashtray.Brand = targetCigarillo.Brand;
            ashtray.CountryOfManufacturing = targetCigarillo.CountryOfManufacturing;
            ashtray.ImageUrl = targetCigarillo.ImageUrl;
            ashtray.Comment = targetCigarillo.Comment;
            ashtray.FiterId = targetCigarillo.FiterId;

            context.SaveChanges();
        }

        public CigarilloDetailsViewModel AddReview(CigarilloDetailsViewModel targetCigarillo, string UserName)
        {
            var entity = new CigarilloReview()
            {
                CigarilloId = targetCigarillo.Id,
                Review = targetCigarillo.AddReviewToCigarillo,
                Commenter = UserName
            };

            context.CigarilloReviews.Add(entity);
            context.SaveChanges();

            targetCigarillo.AddReviewToCigarillo = String.Empty;

            return targetCigarillo;
        }

        public int DeleteReview(int reviewId)
        {
            var targetReview = context.CigarilloReviews
                 .Where(x => x.Id == reviewId)
                 .FirstOrDefault();

            var targetCigarilloId = targetReview.CigarilloId;

            context.CigarilloReviews.Remove(targetReview);
            context.SaveChanges();
            return (targetCigarilloId);
        }

        public int EditReview(int cigarilloId, string changedReview)
        {
            var targetReview = context.CigarilloReviews
               .Where(x => x.Id == cigarilloId)
               .FirstOrDefault();

            var targetAshtreyId = targetReview.CigarilloId;

            targetReview.Review = changedReview;

            context.SaveChanges();
            return (targetAshtreyId);
        }
    }
}
