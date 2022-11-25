using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using Microsoft.AspNetCore.Mvc;

namespace CigarWorld.Controllers
{
    public class CigarController : Controller
    {
        private readonly ICigarService cigarService;

        public CigarController(ICigarService _cigarService)
        {
            cigarService = _cigarService;
        }


        [HttpGet]
        public async Task<IActionResult> Cigar()
        {
            var model = await cigarService.GetAllCigarsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddCigar()
        {
            var model = new AddCigarViewModel()
            {
                StrengthTypes = await cigarService.GetStrengthTypeAsync()
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddCigar(AddCigarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await cigarService.AddCigarsAsync(model);

                return RedirectToAction(nameof(Cigar));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }
    }
}
