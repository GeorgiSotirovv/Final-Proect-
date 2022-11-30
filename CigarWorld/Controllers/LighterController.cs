using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

            return RedirectToAction("Cigar", "Cigar");
        }


        public IActionResult Details(int Id)
        {
            try
            {
                var model = lighterService.GetDetailsAsync(Id).Result;
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IActionResult> RemoveFromCollection(int lighterId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await lighterService.RemoveFromFavoritesAsync(lighterId, userId);

            return RedirectToAction("Cigar", "Cigar");
        }

        public async Task<IActionResult> RemoveFromDataBase(int lighterId)
        {
            await lighterService.RemoveFromDatabaseAsync(lighterId);

            return RedirectToAction("Cigar", "Cigar");
        }
    }
}
