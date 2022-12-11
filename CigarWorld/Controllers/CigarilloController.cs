using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using static CigarWorld.WebConstants;

namespace CigarWorld.Controllers
{
    public class CigarilloController : Controller
    {
        private readonly ICigarilloService cigarilloService;


        public CigarilloController(ICigarilloService _cigarilloService)
        {
            cigarilloService = _cigarilloService;
        }

        [HttpGet]
        public async Task<IActionResult> Cigarillo()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = await cigarilloService.GetAllCigarillosAsync(userId);

            return View(model);
        }


        public async Task<IActionResult> AddFavoriteCigarillo(int cigarilloId)
        {
            try
            {
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                await cigarilloService.AddFavoriteCigarilloAsync(cigarilloId, userId);

                TempData[GlobalAddToFavoritesMessage] = "You added Cigarillo to your collection successfully!";
            }
            catch (Exception ex)
            {
                TempData[GlobalExeptionError] = ex.Message;
            }


            return RedirectToAction("Cigarillo", "Cigarillo");
        }


        public async Task<IActionResult> RemoveFromCollection(int cigarilloId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await cigarilloService.RemoveFromFavoritesAsync(cigarilloId, userId);

            TempData[GlobalDeleteFromFavoritesMessage] = "You deleted Cigarillo from your collection successfully!";

            string referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
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
                return RedirectToAction("Cigarillo", "Cigarillo");
            }

            try
            {
                var curUser = this.User.Identity.Name;

                var model = cigarilloService.GetDetailsAsync(Id, curUser).Result;
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Cigarillo", "Cigarillo");
            }
        }

        [HttpPost]
        public IActionResult Details(CigarilloDetailsViewModel targetCigarillo)
        {
            var curUser = this.User.Identity.Name;

            cigarilloService.AddReview(targetCigarillo, curUser);

            return RedirectToAction("Details", "Cigarillo", new { id = targetCigarillo.Id });
        }

        public IActionResult DeleteComment(int ReviewId)
        {
            var targetAshtrayId = cigarilloService.DeleteReview(ReviewId);

            return RedirectToAction("Details", "Cigarillo", new { id = targetAshtrayId });
        }

        [HttpPost]
        public IActionResult EditComment(int ReviewId, string petko)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Cigarillo", "Cigarillo");
            }

            var targetCigarId = cigarilloService.EditReview(ReviewId, petko);

            return RedirectToAction("Details", "Cigarillo", new { id = targetCigarId });
        }
    }
}
