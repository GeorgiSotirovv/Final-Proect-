using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            var model = await cigarilloService.GetAllCigarillosAsync();

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> AddCigarillo()
        {
            var model = new AddCigarilloViewModel()
            {
                FilterTypes = await cigarilloService.GetTypesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCigarillo(AddCigarilloViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await cigarilloService.AddCigarilloAsync(model);

                return RedirectToAction(nameof(Cigarillo));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

        public async Task<IActionResult> AddFavoriteCigarillo(int cigarilloId)
        {

            try
            {
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await cigarilloService.AddFavoriteCigarilloAsync(cigarilloId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Cigarillo", "Cigarillo");
        }


        public IActionResult Details(int Id)
        {
            try
            {
                var model = cigarilloService.GetDetailsAsync(Id).Result;
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
