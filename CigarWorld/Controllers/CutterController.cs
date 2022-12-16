using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static CigarWorld.WebConstants;

namespace CigarWorld.Controllers
{

    public class CutterController : Controller
    {
        private readonly ICutterService cutterService;

        public CutterController(ICutterService _cutterService)
        {
            cutterService = _cutterService;
        }

        [HttpGet]
        public async Task<IActionResult> Cutter()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = await cutterService.GetCuttersAllAsync(userId);

            return View(model);
        }

       
        public async Task<IActionResult> AddFavoriteCutter(int cutterId)
        {
            try
            {
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                await cutterService.AddFavoriteCutterAsync(cutterId, userId);

                TempData[GlobalAddToFavoritesMessage] = "You added Cutter to your collection successfully!";
            }
            catch (Exception ex)
            {
                TempData[GlobalExeptionError] = ex.Message;
            }

            return RedirectToAction("Cutter", "Cutter");
        }


        public IActionResult Details(int Id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            if (!ModelState.IsValid)
            {
                TempData[GlobalExeptionError] = "Someting went wrong";

                return RedirectToAction("Cutter", "Cutter");
            }

            try
            {
                var curUser = this.User.Identity.Name;

                var model = cutterService.GetDetailsAsync(Id, curUser).Result;
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Cutter", "Cutter");
            }
        }

        [HttpPost]
        public IActionResult Details(CutterDetailsViewModel targetCutter)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            if (targetCutter.AddReviewToCutter == null)
            {
                TempData[GlobalExeptionError] = GlobalExeptionError;

                return RedirectToAction("Details", "Cutter", new { id = targetCutter.Id });
            }

            var curUser = this.User.Identity.Name;

            cutterService.AddReview(targetCutter, curUser);

            return RedirectToAction("Details", "Cutter", new { id = targetCutter.Id });
        }

        

        public async Task<IActionResult> RemoveFromCollection(int cutterId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await cutterService.RemoveFromFavoritesAsync(cutterId, userId);

            TempData[GlobalDeleteFromFavoritesMessage] = "You deleted Cutter from your collection successfully!";

            string referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

 
        public IActionResult DeleteReview(int ReviewId)
        {
            var targetCutterId = cutterService.DeleteReview(ReviewId);

            return RedirectToAction("Details", "Cutter", new { id = targetCutterId });
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
                return RedirectToAction("Cutter", "Cutter");
            }

            var targetCutterId = cutterService.EditReview(ReviewId, changetReview);

            return RedirectToAction("Details", "Cutter", new { id = targetCutterId });
        }
    }
}
