using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using CigarWorld.Models.EditViewModels;
using CigarWorld.Models.DetailsModels;
using static CigarWorld.WebConstants;

namespace CigarWorld.Controllers
{
    public class CigarCaseController : Controller
    {
        private readonly ICigarCaseService cigarCaseService;

        public CigarCaseController(ICigarCaseService _cigarCaseService)
        {
            cigarCaseService = _cigarCaseService;
        }

        [HttpGet]
        public async Task<IActionResult> CigarPocketCase()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = await cigarCaseService.GetAllAsyncCigarCase(userId);

            return View(model);
        }

       
        public async Task<IActionResult> AddFavoriteCigarPocketCase(int cigarPocketCaseId)
        {

            try
            {
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                await cigarCaseService.AddCigarCaseToFavoritesAsync(cigarPocketCaseId, userId);

                TempData[GlobalAddToFavoritesMessage] = "You added Lighter to your collection successfully!";
            }
            catch (Exception ex)
            {
                TempData[GlobalExeptionError] = ex.Message;
            }

            return RedirectToAction("CigarPocketCase", "CigarCase");
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
                return RedirectToAction("Details", "CigarCase");
            }

            try
            {
                var curUser = this.User.Identity.Name;

                var model = cigarCaseService.GetDetailsAsync(Id, curUser).Result;
                return View(model);

            }
            catch (Exception)
            {
                return RedirectToAction("CigarPocketCase", "CigarCase");
            }
        }

        [HttpPost]
        public IActionResult Details(CigarCaseDetailsViewModel targetCPC)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            if (targetCPC.AddReviewToCigarPocketCase == null)
            {
                TempData[GlobalExeptionError] = GlobalExeptionError;

                return RedirectToAction("Details", "CigarCase", new { id = targetCPC.Id });
            }

            var curUser = this.User.Identity.Name;

            cigarCaseService.AddReview(targetCPC, curUser);

            return RedirectToAction("Details", "CigarCase", new { id = targetCPC.Id });
        }


        public async Task<IActionResult> RemoveFromCollection(int CPCId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await cigarCaseService.RemoveFromFavoritesAsync(CPCId, userId);

            TempData[GlobalDeleteFromFavoritesMessage] = "You deleted Lighter from your collection successfully!";

            string referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        public async Task<IActionResult> RemoveFromDataBase(int cigarPocketCaseId)
        {
            await cigarCaseService.RemoveFromDatabaseAsync(cigarPocketCaseId);

            return RedirectToAction("CigarPocketCase", "CigarCase");
        }

        public IActionResult DeleteReview(int ReviewId)
        {
            var targetAshtrayId = cigarCaseService.DeleteReview(ReviewId);

            return RedirectToAction("Details", "CigarCase", new { id = targetAshtrayId });
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
                return RedirectToAction("CigarPocketCase", "CigarCase");
            }

            var targetCigarCaseId = cigarCaseService.EditReview(ReviewId, changetReview);

            return RedirectToAction("Details", "CigarCase", new { id = targetCigarCaseId });
        }
    }
}