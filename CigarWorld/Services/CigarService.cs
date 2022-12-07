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

        public async Task<IEnumerable<AllCigarViewModel>> GetAllCigarsAsync(string userId)
        {
            var favorites = await context.UserCigars
                //.Include(x => x.ApplicationUser)
                .Include(x => x.Cigar)
                .ThenInclude(x => x.StrengthType)
                .Where(x => x.UserId == userId)
                .ToListAsync();

            var cigar = await context.Cigars
                .Include(x => x.StrengthType)
                .ToListAsync();

            return cigar
                .Select(m => new AllCigarViewModel()
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
                    IsFavorite = favorites.Where(x => x.CigarId == m.Id).Count() > 0
                });
        }

        public async Task AddFavoriteCigarAsync(int cigarId, string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("Invalid user Id.");
            }

            var cigar = await context.Cigars.FirstOrDefaultAsync(a => a.Id == cigarId);

            if (cigar == null)
            {
                throw new ArgumentException("Invalid Cigar ID.");
            }

            if (user.UserCigars.Any(m => m.CigarId == cigarId))
            {
                throw new ArgumentException("This Cigar is alredy added.");
            }

            if (!user.UserCigars.Any(m => m.CigarId == cigarId))
            {
                user.UserCigars.Add(new UserCigar()
                {
                    CigarId = cigar.Id,
                    UserId = user.Id,
                    Cigar = cigar,
                    ApplicationUser = user
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MyFavoriteCigarViewModel>> GetMineCigarsAsync(string userId)
        {

            var user = await context.Users
              .Where(u => u.Id == userId)
              .Include(u => u.UserCigars)
              .ThenInclude(um => um.Cigar)
              .ThenInclude(m => m.StrengthType)
              .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user Id");
            }

            return user.UserCigars
                .Select(m => new MyFavoriteCigarViewModel()
                {
                    Id = m.CigarId,
                    Brand = m.Cigar.Brand,
                    ImageUrl = m.Cigar.ImageUrl,
                    Comment = m.Cigar.Comment,
                    CountryOfManufacturing = m.Cigar.CountryOfManufacturing,
                    StrengthType = m.Cigar.StrengthType.Name,
                    Format = m?.Cigar.Format,
                    Length = m.Cigar.Length,
                    Ring = m.Cigar.Ring,
                    SmokingDuration = m.Cigar.SmokingDuration,
                });

        }

        public async Task RemoveFromFavoritesAsync(int cigarId, string userId)
        {
            var targetUserCigar = context.UserCigars
                .Where(x => x.CigarId == cigarId)
                .Where(x => x.UserId == userId)
                .FirstOrDefault();

            if (targetUserCigar == null)
            {
                throw new ArgumentException("Invalid user Id");
            }

            context.UserCigars.Remove(targetUserCigar);

            await context.SaveChangesAsync();

        }

        public async Task<CigarDetailsViewModel> GetDetailsAsync(int cigarId, string userName)
        {
            var cigar = await context.Cigars
              .Where(u => u.Id == cigarId)
              .Include(u => u.CigarReviews)
              .Include(m => m.StrengthType)
              .FirstOrDefaultAsync();

            if (cigar == null)
            {
                throw new ArgumentException("Invalid Cigar ID");
            }

            return new CigarDetailsViewModel()
            {
                Brand = cigar.Brand,
                CountryOfManufacturing = cigar.CountryOfManufacturing,
                ImageUrl = cigar.ImageUrl,
                Comment = cigar.Comment,
                Format = cigar.Format,
                Length = cigar.Length,
                Ring = cigar.Ring,
                SmokingDuration = cigar.SmokingDuration,
                StrengthType = cigar?.StrengthType?.Name,
                CigarReviews = cigar.CigarReviews,
                UserName = userName
            };
        }

        public async Task RemoveFromDatabaseAsync(int cigarId)
        {

            var cigar = await context.Cigars
                .Where(u => u.Id == cigarId)
                .FirstOrDefaultAsync();


            if (cigar == null)
            {
                throw new ArgumentException("Invalid Cigar Id");
            }

            context.Cigars.Remove(cigar);

            await context.SaveChangesAsync();
        }

        public async Task EditCigar(int cigarId)
        {
            var ashtray = await context.Cigars
                .Where(u => u.Id == cigarId)
                .FirstOrDefaultAsync();
        }

        public async Task<EditCigarViewModel> GetInformationForCigar(int cigarId)
        {
            var cigar = await context.Cigars
                .Where(u => u.Id == cigarId)
                .FirstOrDefaultAsync();

            var result = new EditCigarViewModel
            {
                Id = cigar.Id,
                Brand = cigar.Brand,
                Comment = cigar.Comment,
                CountryOfManufacturing = cigar.CountryOfManufacturing,
                ImageUrl = cigar.ImageUrl,
                Format = cigar.Format,
                Length = cigar.Length,
                Ring = cigar.Ring,
                SmokingDuration = cigar.SmokingDuration,
                StrengthId = cigar.StrengthId,
                StrengthTypes = this.GetStrengthTypeAsync().Result
            };

            return result;
        }

        public void EditCigarInformation(EditCigarViewModel targetCigar)
        {
            var cigar = context.Cigars.
                Where(u => u.Id == targetCigar.Id)
                .FirstOrDefault();

            if (cigar == null)
            {
                throw new ArgumentException("Invalid Cigar");
            }

            cigar.Brand = targetCigar.Brand;
            cigar.CountryOfManufacturing = targetCigar.CountryOfManufacturing;
            cigar.ImageUrl = targetCigar.ImageUrl;
            cigar.Comment = targetCigar.Comment;
            cigar.Length = targetCigar.Length;
            cigar.SmokingDuration = targetCigar.SmokingDuration;
            cigar.Ring = targetCigar.Ring;
            cigar.Format = targetCigar.Format;
            cigar.StrengthId = targetCigar.StrengthId;
            cigar.Comment = targetCigar.Comment;

            context.SaveChanges();
        }

        public CigarDetailsViewModel AddReview(CigarDetailsViewModel targetCigar, string UserName)
        {
            var entity = new CigarReview()
            {
                CigarId = targetCigar.Id,
                Review = targetCigar.AddReviewToCigar,
                Commenter = UserName
            };

            context.CigarReviews.Add(entity);
            context.SaveChanges();

            targetCigar.AddReviewToCigar = String.Empty;

            return targetCigar;
        }

        public int DeleteReview(int reviewId)
        {
            var targetReview = context.CigarReviews
             .Where(x => x.Id == reviewId)
             .FirstOrDefault();

            var targetCigarId = targetReview.CigarId;

            context.CigarReviews.Remove(targetReview);
            context.SaveChanges();
            return (targetCigarId);
        }

        public int EditReview(int cigarId, string changedReview)
        {
            var targetReview = context.CigarReviews
               .Where(x => x.Id == cigarId)
               .FirstOrDefault();

            var targetCigarId = targetReview.CigarId;

            targetReview.Review = changedReview;

            context.SaveChanges();
            return (targetCigarId);
        }
    }
}
