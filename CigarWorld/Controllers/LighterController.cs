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

    public class LighterController : Controller
    {
        private readonly ILighterService lighterService;

        public LighterController(ILighterService _lighterService)
        {
            lighterService = _lighterService;
        }

        [HttpGet]
        public async Task<IActionResult> Lighter()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = await lighterService.GetAllLighterAsync(userId);

            return View(model);
        }

        public async Task<IActionResult> AddFavoriteLighter(int lighterId)
        {
            try
            {
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                await lighterService.AddFavoriteLighterAsync(lighterId, userId);

                TempData[GlobalAddToFavoritesMessage] = "You added Lighter to your collection successfully!";
            }
            catch (Exception ex)
            {
                TempData[GlobalExeptionError] = ex.Message;
            }

            return RedirectToAction("Lighter", "Lighter");
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
                TempData[GlobalExeptionError] = "Someting went wrong";

                return RedirectToAction("Humidor", "Humidor");
            }

            try
            {
                var curUser = this.User.Identity.Name;

                var model = lighterService.GetDetailsAsync(Id, curUser).Result;
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Details(LighterDetailsViewModel Lighter)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            if (Lighter.AddReviewToLighter == null)
            {
                TempData[GlobalExeptionError] = GlobalExeptionError;

                return RedirectToAction("Details", "Humidor", new { id = Lighter.Id });
            }

            var curUser = this.User.Identity.Name;

            lighterService.AddReview(Lighter, curUser);

            return RedirectToAction("Details", "Lighter", new { id = Lighter.Id });
        }

        public async Task<IActionResult> RemoveFromCollection(int lighterId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await lighterService.RemoveFromFavoritesAsync(lighterId, userId);

            TempData[GlobalDeleteFromFavoritesMessage] = "You deleted Lighter from your collection successfully!";

            string referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        public IActionResult DeleteReview(int ReviewId)
        {
            var targetLighterId = lighterService.DeleteReview(ReviewId);

            return RedirectToAction("Details", "Lighter", new { id = targetLighterId });
        }

        [HttpPost]
        public IActionResult EditReview(int ReviewId, string changetReview)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Lighter", "Lighter");
            }

            var targetLighterId = lighterService.EditReview(ReviewId, changetReview);

            return RedirectToAction("Details", "Lighter", new { id = targetLighterId });
        }
    }
}
