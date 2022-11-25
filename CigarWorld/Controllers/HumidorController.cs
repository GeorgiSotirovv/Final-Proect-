using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            var model = await humidorsService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddHumidor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddHumidor(AddHumidorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await humidorsService.AddHumidorAsync(model);

                return RedirectToAction(nameof(Humidor));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong!");

                return View(model);
            }
        }

        public async Task<IActionResult> AddFavoriteHumidor(int humidorId)
        {
            try
            {
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await humidorsService.AddFavoriteHumidorAsync(humidorId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Cigar", "Cigar");
        }
    }
}
