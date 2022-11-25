using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> AddLighter()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddLighter(AddLighterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await lighterService.AddLighterAsync(model);

                return RedirectToAction(nameof(Lighter));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong!");

                return View(model);
            }
        }
    }
}
