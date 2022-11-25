using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            var model = await cigarCaseService.GetAllAsyncCigarCase();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddCigarPocketCase()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCigarPocketCase(AddCigarPocketCaseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await cigarCaseService.AddCigarCasesAsync(model);

                return RedirectToAction(nameof(CigarPocketCase));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong!");

                return View(model);
            }
        }


        public async Task<IActionResult> AddFavoriteCigarPocketCase(int cigarPocketCaseId)
        {

            try
            {
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await cigarCaseService.AddCigarCaseToFavoritesAsync(cigarPocketCaseId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Cigar","Cigar");
        }
    }
}
