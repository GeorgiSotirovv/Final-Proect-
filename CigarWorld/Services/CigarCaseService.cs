using CigarWorld.Contracts;
using CigarWorld.Data;
using CigarWorld.Data.Models;
using CigarWorld.Data.Models.ManyToMany;
using CigarWorld.Data.Models.Reviews;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using CigarWorld.Models.JustModels;
using CigarWorld.Models.Models;
using CigarWorld.Models.MyFavoriteViewModels;
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

        public async Task AddCigarCasesAsync(AddCigarPocketCaseViewModel model)
        {
            var entity = new CigarPocketCase()
            {
                Brand = model.Brand,
                CountryOfManufacturing = model.CountryOfManufacturing,
                ImageUrl = model.ImageUrl,
                Comment = model.Comment,
                Capacity = model.Capacity,
                MaterialOfManufacture = model.MaterialOfManufacture
            };
            await context.CigarPocketCases.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task AddCigarCaseToFavoritesAsync(int cigarPocketCaseId, string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("Invalid user Id.");
            }

            var cigarPocketCase = await context.CigarPocketCases.FirstOrDefaultAsync(a => a.Id == cigarPocketCaseId);

            if (cigarPocketCase == null)
            {
                throw new ArgumentException("Invalid Case Id.");
            }


            if (!user.UserCigarPocketCases.Any(m => m.CigarPocketCaseId == cigarPocketCaseId))
            {
                user.UserCigarPocketCases.Add(new UserCigarPocketCase()
                {
                    CigarPocketCaseId = cigarPocketCase.Id,
                    UserId = user.Id,
                    CigarPocketCase = cigarPocketCase,
                    ApplicationUser = user
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveFromFavoritesAsync(int CPCId, string userId)
        {
            var targetUserCPC = context.UserCigarPocketCases
               .Where(x => x.CigarPocketCaseId == CPCId)
               .Where(x => x.UserId == userId)
               .FirstOrDefault();

            if (targetUserCPC == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            context.UserCigarPocketCases.Remove(targetUserCPC);

            await context.SaveChangesAsync();

        }


        public async Task<IEnumerable<AllCigarPocketCaseViewModel>> GetAllAsyncCigarCase(string userId)
        {
            var favorites = await context.UserCigarPocketCases
             .Include(x => x.CigarPocketCase)
             .Where(x => x.UserId == userId)
             .ToListAsync();


            var entities = await context.CigarPocketCases
                .ToListAsync();

            return entities
                .Select(m => new AllCigarPocketCaseViewModel()
                {
                    Id = m.Id,
                    Brand = m.Brand,
                    CountryOfManufacturing = m.CountryOfManufacturing,
                    ImageUrl = m.ImageUrl,
                    Comment = m.Comment,
                    Capacity = m.Capacity,
                    MaterialOfManufacture = m.MaterialOfManufacture,
                    IsFavorite = favorites.Where(x => x.CigarPocketCaseId == m.Id).Count() > 0
                });
        }

        public async Task<CigarCaseDetailsViewModel> GetDetailsAsync(int CPCId, string userName)
        {

            var CPC = await context.CigarPocketCases
              .Where(u => u.Id == CPCId)
              .Include(m => m.CigarPocketCaseReviews)
              .FirstOrDefaultAsync();

            if (CPC == null)
            {
                throw new ArgumentException("Invalid Cigar Pocket Case Id");
            }

            return new CigarCaseDetailsViewModel()
            {
                Brand = CPC.Brand,
                CountryOfManufacturing = CPC.CountryOfManufacturing,
                ImageUrl = CPC.ImageUrl,
                Comment = CPC.Comment,
                MaterialOfManufacture = CPC.MaterialOfManufacture,
                Capacity = CPC.Capacity,
                CigarPocketCaseReviews = CPC.CigarPocketCaseReviews,
                UserName = userName
            };
        }


        public async Task<IEnumerable<MyFavoriteCigarPocketCaseViewModel>> GetMineCPCAsync(string userId)
        {
            var user = await context.Users
              .Where(u => u.Id == userId)
              .Include(u => u.UserCigarPocketCases)
              .ThenInclude(um => um.CigarPocketCase)
              .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.UserCigarPocketCases
                .Select(m => new MyFavoriteCigarPocketCaseViewModel()
                {
                    Id = m.CigarPocketCaseId,
                    Brand = m.CigarPocketCase.Brand,
                    ImageUrl = m.CigarPocketCase.ImageUrl,
                    Comment = m.CigarPocketCase.Comment,
                    CountryOfManufacturing = m.CigarPocketCase.CountryOfManufacturing,
                    Capacity = m.CigarPocketCase.Capacity,
                    MaterialOfManufacture = m.CigarPocketCase.MaterialOfManufacture
                });
        }

        public async Task RemoveFromCollectionAsync(int CPCId, string userId)
        {
            var targetUserCPC = context.UserCigarPocketCases
               .Where(x => x.CigarPocketCaseId == CPCId)
               .Where(x => x.UserId == userId)
               .FirstOrDefault();

            if (targetUserCPC == null)
            {
                throw new ArgumentException("Invalid user Id");
            }

            context.UserCigarPocketCases.Remove(targetUserCPC);

            await context.SaveChangesAsync();
        }

        public async Task RemoveFromDatabaseAsync(int cigarPocketCaseId)
        {

            var CPC = await context.CigarPocketCases
                .Where(u => u.Id == cigarPocketCaseId)
                .FirstOrDefaultAsync();


            if (CPC == null)
            {
                throw new ArgumentException("Invalid Cigar Pocket Case Id");
            }

            context.CigarPocketCases.Remove(CPC);

            await context.SaveChangesAsync();

        }


        public async Task EditCigarPocketCase(int CPCId)
        {
            var cigar = await context.CigarPocketCases
                 .Where(u => u.Id == CPCId)
                 .FirstOrDefaultAsync();
        }

        public async Task<EditCigarPocketCaseViewModel> GetInformationForCigarPocketCase(int CPCId)
        {
            var CPC = await context.CigarPocketCases
                .Where(u => u.Id == CPCId)
                .FirstOrDefaultAsync();


            var result = new EditCigarPocketCaseViewModel
            {
                Id = CPC.Id,
                Brand = CPC.Brand,
                Comment = CPC.Comment,
                CountryOfManufacturing = CPC.CountryOfManufacturing,
                ImageUrl = CPC.ImageUrl,
                MaterialOfManufacture = CPC.MaterialOfManufacture,
                Capacity = CPC.Capacity
            };

            return result;
        }

        public void EditCigarPocketCaseInformation(EditCigarPocketCaseViewModel targetCPC)
        {
            var CPC = context.CigarPocketCases.
               Where(u => u.Id == targetCPC.Id)
               .FirstOrDefault();

            if (CPC == null)
            {
                throw new ArgumentException("Invalid cigar pocket case");
            }

            CPC.Brand = targetCPC.Brand;
            CPC.CountryOfManufacturing = targetCPC.CountryOfManufacturing;
            CPC.ImageUrl = targetCPC.ImageUrl;
            CPC.Comment = targetCPC.Comment;
            CPC.MaterialOfManufacture = targetCPC.MaterialOfManufacture;
            CPC.Capacity = targetCPC.Capacity;

            context.SaveChanges();
        }

        public CigarCaseDetailsViewModel AddReview(CigarCaseDetailsViewModel targetCPC, string UserName)
        {
            var entity = new CigarPocketCaseReview()
            {
                CigarPocketCaseId = targetCPC.Id,
                Review = targetCPC.AddReviewToCigarPocketCase,
                Commenter = UserName
            };

            context.CigarPocketCaseReviews.Add(entity);
            context.SaveChanges();

            targetCPC.AddReviewToCigarPocketCase = String.Empty;

            return targetCPC;
        }

        public int DeleteReview(int reviewId)
        {
            var targetReview = context.CigarPocketCaseReviews
                .Where(x => x.Id == reviewId)
                .FirstOrDefault();

            var targetCPCId = targetReview.CigarPocketCaseId;

            context.CigarPocketCaseReviews.Remove(targetReview);
            context.SaveChanges();
            return (targetCPCId);
        }

        public int EditReview(int CPCId, string changedReview)
        {
            var targetReview = context.CigarPocketCaseReviews
               .Where(x => x.Id == CPCId)
               .FirstOrDefault();

            var targetAshtreyId = targetReview.CigarPocketCaseId;

            targetReview.Review = changedReview;

            context.SaveChanges();
            return (targetAshtreyId);
        }
    }
}
