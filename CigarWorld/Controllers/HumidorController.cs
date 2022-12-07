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
            try
            {
                var curUser = this.User.Identity.Name;

                var model = humidorsService.GetDetailsAsync(Id, curUser).Result;
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Details(HumidorDetailsViewModel Humidor)
        {
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
        

        public IActionResult DeleteComment(int ReviewId)
        {
            var targetHumidorId = humidorsService.DeleteReview(ReviewId);

            return RedirectToAction("Details", "Humidor", new { id = targetHumidorId });
        }


        [HttpPost]
        public IActionResult EditComment(int ReviewId, string petko)
        {
            var targetHumidorId = humidorsService.EditReview(ReviewId, petko);

            return RedirectToAction("Details", "Humidor", new { id = targetHumidorId });
        }
    }
}
