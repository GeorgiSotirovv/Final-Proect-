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
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = await ashtrayService.GetAllAshtrayAsync(userId);

            return View(model);
        }


        public async Task<IActionResult> AddFavoriteAshtray(int ashtrayId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Ashtray", "Ashtray");
            }

            try
            {
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                await ashtrayService.AddAshtrayToFavoritesAsync(ashtrayId, userId);

                TempData[GlobalAddToFavoritesMessage] = "You added Ashtray to your collection successfully!";
            }
            catch (Exception ex)
            {
                TempData[GlobalExeptionError] = ex.Message;
            }

            return RedirectToAction("Ashtray", "Ashtray");
        }


        [HttpGet]
        public IActionResult Details(int Id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Details", "Ashtray");
            }

            try
            {
                var curUser = this.User.Identity.Name;

                var model = ashtrayService.GetDetailsAsync(Id, curUser).Result;
                return View(model);

            }
            catch (Exception)
            {
                return RedirectToAction("Ashtray", "Ashtray");
            }

           
        }

        [HttpPost]
        public IActionResult Details(AshtrayDetailsViewModel targetAshtray)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            if (targetAshtray.AddReviewToAshtray == null)
            {
                TempData[GlobalExeptionError] = GlobalExeptionError;

                return RedirectToAction("Details", "Ashtray", new { id = targetAshtray.Id });
            }

            var curUser = this.User.Identity.Name;

            ashtrayService.AddReview(targetAshtray, curUser);

            return RedirectToAction("Details", "Ashtray", new { id = targetAshtray.Id });
        }

        public async Task<IActionResult> RemoveFromCollection(int ashtrayId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            if (!ModelState.IsValid)
            {
                TempData[GlobalExeptionError] = "Someting went wrong";

                return RedirectToAction("Ashtray", "Ashtray");
            }

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await ashtrayService.RemoveFromFavoritesAsync(ashtrayId, userId);

            TempData[GlobalDeleteFromFavoritesMessage] = "You deleted Ashtray from your collection successfully!";

            string referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }


        public IActionResult DeleteReview(int ReviewId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            var targetAshtrayId = ashtrayService.DeleteReview(ReviewId);

            return RedirectToAction("Details", "Ashtray", new { id = targetAshtrayId });
        }


        [HttpPost]
        public IActionResult EditReview(int ReviewId, string petko)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Ashtray", "Ashtray");
            }

            var targetAshtrayId = ashtrayService.EditReview(ReviewId, petko);

            return RedirectToAction("Details", "Ashtray", new { id = targetAshtrayId });
        }
    }
}
