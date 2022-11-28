using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CigarWorld.Controllers
{
    [Authorize]
    public class AshtrayController : Controller
    {
        private readonly IAshtrayService ashtrayService;

        public AshtrayController(IAshtrayService _AshtrayService)
        {
            ashtrayService = _AshtrayService;
        }

        [HttpGet]
        public async Task<IActionResult> Ashtrays()
        {
            var model = await ashtrayService.GetAllAshtrayAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddAshtray()
        {
            var model = new AddAshtrayViewModel()
            {
                AshtrayTypes = await ashtrayService.GetTypesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddAshtray(AddAshtrayViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await ashtrayService.AddAshtraysAsync(model);

                return RedirectToAction("Cigar", "Cigar");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

        public async Task<IActionResult> AddFavoriteAshtray(int ashtrayId)
        {

            try
            {
                
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await ashtrayService.AddAshtrayToFavoritesAsync(ashtrayId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Cigar", "Cigar");
        }

        public IActionResult Details(int Id)
        {
            return View();
        }

    }
}
