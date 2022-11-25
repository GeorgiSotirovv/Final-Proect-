using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using Microsoft.AspNetCore.Mvc;

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
    }
}
