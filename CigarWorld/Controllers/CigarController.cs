using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static CigarWorld.WebConstants;

namespace CigarWorld.Controllers
{
    public class CigarController : Controller
    {
        private readonly ICigarService cigarService;

        public CigarController(ICigarService _cigarService)
        {
            cigarService = _cigarService;
        }


        [HttpGet]
        public async Task<IActionResult> Cigar()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var model = await cigarService.GetAllCigarsAsync(userId);

            return View(model);
        }


        public async Task<IActionResult> AddFavoriteCigar(int cigarId)
        {
            try
            {
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await cigarService.AddFavoriteCigarAsync(cigarId, userId);

                TempData[GlobalAddToFavoritesMessage] = "You added Cigar to your collection successfully!";
            }
            catch (Exception ex)
            {
                TempData[GlobalExeptionError] = ex.Message;
            }


            return RedirectToAction("Cigar", "Cigar");
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

                return RedirectToAction("Details", "Cigar");
            }

            try
            {
                var curUser = this.User.Identity.Name;

                var model = cigarService.GetDetailsAsync(Id, curUser).Result;
                return View(model);

            }
            catch (Exception)
            {
                return RedirectToAction("Cigar", "Cigar");
            }
        }

        [HttpPost]
        public IActionResult Details(CigarDetailsViewModel targetCigar)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            if (targetCigar.AddReviewToCigar == null)
            {
                TempData[GlobalExeptionError] = GlobalExeptionError;

                return RedirectToAction("Details", "Cigar", new { id = targetCigar.Id });
            }

            var curUser = this.User.Identity.Name;

            cigarService.AddReview(targetCigar, curUser);

            return RedirectToAction("Details", "Cigar", new { id = targetCigar.Id });
        }

        public async Task<IActionResult> RemoveFromCollection(int cigarId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await cigarService.RemoveFromFavoritesAsync(cigarId, userId);

            TempData[GlobalDeleteFromFavoritesMessage] = "You deleted Cigar from your collection successfully!";

            string referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        public IActionResult DeleteReview(int ReviewId)
        {
            var targetCigarId = cigarService.DeleteReview(ReviewId);

            return RedirectToAction("Details", "Cigar", new { id = targetCigarId });
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
                return RedirectToAction("Cigar", "Cigar");
            }

            var targetCigarId = cigarService.EditReview(ReviewId, petko);

            return RedirectToAction("Details", "Cigar", new { id = targetCigarId });
        }
    }
}
