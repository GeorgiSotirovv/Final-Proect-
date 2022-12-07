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
    public class CutterService : ICutterService
    {
        private readonly CigarWorldDbContext context;

        public CutterService(CigarWorldDbContext _context)
        {
            context = _context;
        }


        public Task CheckIfIdExist(int movieId)
        {
            throw new NotImplementedException();
        }



        public async Task<IEnumerable<CutterType>> GetTypesAsync()
        {
            return await context.CutterTypes.ToListAsync();
        }

        public async Task AddCutterAsync(AddCutterViewModel model)
        {
            var entity = new Cutter()
            {
                Brand = model.Brand,
                CountryOfManufacturing = model.CountryOfManufacturing,
                ImageUrl = model.ImageUrl,
                Comment = model.Comment,
                TypeId = model.TypeId
            };
            await context.Cutters.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllCutterViewModel>> GetAllAsync()
        {
            var entities = await context.Cutters
                .Include(x => x.CutterType)
                .ToListAsync();

            return entities
                .Select(m => new AllCutterViewModel()
                {
                    Id = m.Id,
                    Brand = m.Brand,
                    CountryOfManufacturing = m.CountryOfManufacturing,
                    ImageUrl = m.ImageUrl,
                    Comment = m.Comment,
                    Type = m?.CutterType?.Name

                });
        }

        public async Task AddFavoriteCutterAsync(int cutterId, string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("Invalid user Id.");
            }

            var cutter = await context.Cutters.FirstOrDefaultAsync(a => a.Id == cutterId);

            if (cutter == null)
            {
                throw new ArgumentException("Invalid Cutter Id.");
            }

            if (cutter.Id == cutterId)
            {
                throw new ArgumentException("This Cutter is already added.");
            }

            if (!user.UserCutters.Any(m => m.CutterId == cutterId))
            {
                user.UserCutters.Add(new UserCutter()
                {
                    CutterId = cutter.Id,
                    UserId = user.Id,
                    Cutter = cutter,
                    ApplicationUser = user
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MyFavoriteCutterViewModel>> GetMineCuttersAsync(string userId)
        {
            var user = await context.Users
              .Where(u => u.Id == userId)
              .Include(u => u.UserCutters)
              .ThenInclude(um => um.Cutter)
              .ThenInclude(m => m.CutterType)
              .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.UserCutters
                .Select(m => new MyFavoriteCutterViewModel()
                {
                    Id = m.CutterId,
                    Brand = m.Cutter.Brand,
                    ImageUrl = m.Cutter.ImageUrl,
                    Comment = m.Cutter.Comment,
                    CountryOfManufacturing = m.Cutter.CountryOfManufacturing,
                    Type = m.Cutter.CutterType.Name
                });
        }

        public async Task RemoveFromFavoritesAsync(int cutterId, string userId)
        {
            var user = await context.Users
               .Where(u => u.Id == userId)
               .Include(u => u.UserCutters)
               .ThenInclude(um => um.Cutter)
                .ThenInclude(m => m.CutterType)
               .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user Id");
            }

            var ashtray = user.UserCutters.FirstOrDefault(m => m.CutterId == cutterId);

            if (ashtray != null)
            {
                user.UserCutters.Remove(ashtray);

                await context.SaveChangesAsync();
            }
        }

        public async Task<CutterDetailsViewModel> GetDetailsAsync(int cutterId, string curUser)
        {
            var cutter = await context.Cutters
              .Where(u => u.Id == cutterId)
              .Include(m => m.CutterReviews)
              .Include(m => m.CutterType)
              .FirstOrDefaultAsync();

            if (cutter == null)
            {
                throw new ArgumentException("Invalid cutter ID");
            }

            return new CutterDetailsViewModel()
            {
                Brand = cutter.Brand,
                ImageUrl = cutter.ImageUrl,
                Comment = cutter.Comment,
                CountryOfManufacturing = cutter.CountryOfManufacturing,
                Type = cutter?.CutterType?.Name,
                CutterReviews = cutter.CutterReviews,
                UserName = curUser
            };
        }

        public async Task RemoveFromDatabaseAsync(int cutterId)
        {

            var cutter = await context.Cutters
                .Where(u => u.Id == cutterId)
                .FirstOrDefaultAsync();


            if (cutter == null)
            {
                throw new ArgumentException("Invalid Cutter Id");
            }

            context.Cutters.Remove(cutter);

            await context.SaveChangesAsync();

        }

        public async Task EditCutter(int cutterId)
        {
            var ashtray = await context.Cutters
                .Where(u => u.Id == cutterId)
                .FirstOrDefaultAsync();
        }

        public async Task<EditCutterViewModel> GetInformationForCutter(int cutterId)
        {
            var cutter = await context.Cutters
                .Where(x => x.Id == cutterId)
                .FirstOrDefaultAsync();

            var result = new EditCutterViewModel
            {
                Id = cutter.Id,
                Brand = cutter.Brand,
                Comment = cutter.Comment,
                CountryOfManufacturing = cutter.CountryOfManufacturing,
                ImageUrl = cutter.ImageUrl,
                TypeId = cutter.TypeId,
                CutterTypes = this.GetTypesAsync().Result
            };

            return result;
        }

        public void EditCutterInformation(EditCutterViewModel targetCutter)
        {
            var cutter = context.Cutters.
                Where(u => u.Id == targetCutter.Id)
                .FirstOrDefault();

            if (cutter == null)
            {
                throw new ArgumentException("Invalid Cutter");
            }

            cutter.Brand = targetCutter.Brand;
            cutter.CountryOfManufacturing = targetCutter.CountryOfManufacturing;
            cutter.ImageUrl = targetCutter.ImageUrl;
            cutter.Comment = targetCutter.Comment;
            cutter.TypeId = targetCutter.TypeId;

            context.SaveChanges();
        }

        public CutterDetailsViewModel AddReview(CutterDetailsViewModel targetCutter, string UserName)
        {
            var entity = new CutterReview()
            {
                CutterId = targetCutter.Id,
                Review = targetCutter.AddReviewToCutter,
                Commenter = UserName
            };

            context.CutterReviews.Add(entity);
            context.SaveChanges();

            targetCutter.AddReviewToCutter = String.Empty;

            return targetCutter;
        }

        public int DeleteReview(int reviewId)
        {
            var targetReview = context.CutterReviews
                .Where(x => x.Id == reviewId)
                .FirstOrDefault();

            var targetCutterId = targetReview.CutterId;

            context.CutterReviews.Remove(targetReview);
            context.SaveChanges();

            return (targetCutterId);
        }

        public int EditReview(int cutterId, string changedReview)
        {
            var targetReview = context.CutterReviews
               .Where(x => x.Id == cutterId)
               .FirstOrDefault();

            var targetCutterId = targetReview.CutterId;

            targetReview.Review = changedReview;

            context.SaveChanges();
            return (targetCutterId);
        }

    }
}
