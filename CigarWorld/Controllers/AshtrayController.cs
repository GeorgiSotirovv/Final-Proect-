using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static CigarWorld.WebConstants;

namespace CigarWorld.Controllers
{
    [Authorize]
    public class AshtrayController : Controller
    {
        private readonly IAshtrayService ashtrayService;

        public AshtrayController(IAshtrayService _AshtrayService)
        {
            ashtrayService = _AshtrayService;
        }

        [HttpGet]
        public async Task<IActionResult> Ashtray()
        {
            var model = await ashtrayService.GetAllAshtrayAsync();

            return View(model);
        }


        public async Task<IActionResult> AddFavoriteAshtray(int ashtrayId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Ashtray", "Ashtray");
            }

            try
            {
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await ashtrayService.AddAshtrayToFavoritesAsync(ashtrayId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            TempData[GlobalAddToFavoritesMessage] = "You added Ashtray to your collection successfully!";

            return RedirectToAction("Ashtray", "Ashtray");
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Ashtray", "Ashtray");
            }

            try
            {
                var curUser = this.User.Identity.Name;

                var model = ashtrayService.GetDetailsAsync(Id, curUser).Result;
                return View(model);

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Details(AshtrayDetailsViewModel targetAshtray)
        {
            var curUser = this.User.Identity.Name;

            ashtrayService.AddReview(targetAshtray, curUser);

            return RedirectToAction("Details", "Ashtray", new { id = targetAshtray.Id });
        }

        public async Task<IActionResult> RemoveFromCollection(int ashtrayId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await ashtrayService.RemoveFromFavoritesAsync(ashtrayId, userId);

            TempData[GlobalDeleteFromFavoritesMessage] = "You deleted Ashtray from your collection successfully!";

            return RedirectToAction("MyCollection", "MyProfile");
        }


        public IActionResult DeleteComment(int ReviewId)
        {
            var targetAshtrayId = ashtrayService.DeleteReview(ReviewId);

            return RedirectToAction("Details", "Ashtray", new { id = targetAshtrayId });
        }

        [HttpPost]
        public IActionResult EditComment(int ReviewId, string petko)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Ashtray", "Ashtray");
            }

            var targetAshtrayId = ashtrayService.EditReview(ReviewId, petko);

            return RedirectToAction("Details", "Ashtray", new { id = targetAshtrayId });
        }
    }
}
