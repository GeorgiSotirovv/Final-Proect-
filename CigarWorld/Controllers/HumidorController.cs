using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using static CigarWorld.WebConstants;

namespace CigarWorld.Controllers
{
    public class HumidorController : Controller
    {
        private readonly IHumidorsService humidorsService;

        public HumidorController(IHumidorsService _humidorsService)
        {
            humidorsService = _humidorsService;
        }

        [HttpGet]
        public async Task<IActionResult> Humidor()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = await humidorsService.GetAllHumidorAsync(userId);

            return View(model);
        }


        public async Task<IActionResult> AddFavoriteHumidor(int humidorId)
        {
            try
            {
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                await humidorsService.AddFavoriteHumidorAsync(humidorId, userId);

                TempData[GlobalAddToFavoritesMessage] = "You added Humidor to your collection successfully!";
            }
            catch (Exception ex)
            {
                TempData[GlobalExeptionError] = ex.Message;
            }


            return RedirectToAction("Humidor", "Humidor");
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

                var model = humidorsService.GetDetailsAsync(Id, curUser).Result;
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Humidor", "Humidor");
            }
        }

        [HttpPost]
        public IActionResult Details(HumidorDetailsViewModel Humidor)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            if (Humidor.AddReviewToHumidor == null)
            {
                TempData[GlobalExeptionError] = GlobalExeptionError;

                return RedirectToAction("Details", "Humidor", new { id = Humidor.Id });
            }

            var curUser = this.User.Identity.Name;

            humidorsService.AddReview(Humidor, curUser);

            return RedirectToAction("Details", "Humidor", new { id = Humidor.Id });
        }

        public async Task<IActionResult> RemoveFromCollection(int humidorId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await humidorsService.RemoveFromFavoritesAsync(humidorId, userId);

            TempData[GlobalDeleteFromFavoritesMessage] = "You deleted Humidor from your collection successfully!";

            string referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }
        

        public IActionResult DeleteReview(int ReviewId)
        {
            var targetHumidorId = humidorsService.DeleteReview(ReviewId);

            return RedirectToAction("Details", "Humidor", new { id = targetHumidorId });
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
                return RedirectToAction("Humidor", "Humidor");
            }

            var targetHumidorId = humidorsService.EditReview(ReviewId, changetReview);

            return RedirectToAction("Details", "Humidor", new { id = targetHumidorId });
        }
    }
}
