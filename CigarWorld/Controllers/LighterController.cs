using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
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
            var model = await lighterService.GetAllAsync();

            return View(model);
        }

        public async Task<IActionResult> AddFavoriteLighter(int lighterId)
        {
            try
            {
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await lighterService.AddFavoriteLighterAsync(lighterId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            TempData[GlobalAddToFavoritesMessage] = "You added Lighter to your collection successfully!";

            return RedirectToAction("Lighter", "Lighter");
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
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
        public IActionResult Details(LighterDetailsViewModel targetLighter)
        {
            var curUser = this.User.Identity.Name;

            lighterService.AddReview(targetLighter, curUser);

            return RedirectToAction("Details", "Lighter", new { id = targetLighter.Id });
        }

        public async Task<IActionResult> RemoveFromCollection(int lighterId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await lighterService.RemoveFromFavoritesAsync(lighterId, userId);

            TempData[GlobalDeleteFromFavoritesMessage] = "You deleted Lighter from your collection successfully!";

            return RedirectToAction("MyCollection", "MyProfile");
        }

        public IActionResult DeleteComment(int ReviewId)
        {
            var targetLighterId = lighterService.DeleteReview(ReviewId);

            return RedirectToAction("Details", "Lighter", new { id = targetLighterId });
        }
    }
}
