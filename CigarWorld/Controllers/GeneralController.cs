using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using Microsoft.AspNetCore.Mvc;

namespace CigarWorld.Controllers
{
    public class GeneralController : Controller
    {
        private readonly IAshtrayService ashtrayService;
        private readonly ICigarCaseService cigarCaseService;
        private readonly ICigarilloService cigarilloService;
        private readonly ICutterService cutterService;
        private readonly IHumidorsService humidorsService;
        private readonly ILighterService lighterService;
        private readonly ICigarService cigarService;

        public GeneralController(IAshtrayService _AshtrayService, ICigarCaseService _cigarCaseService,ICigarilloService _cigarilloService,
            ICutterService _cutterService, IHumidorsService _humidorsService, ILighterService _lighterService, ICigarService _cigarService)
        {
            ashtrayService = _AshtrayService;
            cigarCaseService = _cigarCaseService;
            cigarilloService = _cigarilloService;
            cutterService = _cutterService;
            humidorsService = _humidorsService;
            lighterService = _lighterService;
            cigarService = _cigarService;
        }

        /// <summary>
        /// Ashtrays logic 
        /// </summary>

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
                Categories = await ashtrayService.GetTypesAsync()
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

                return RedirectToAction(nameof(Cigar));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }


        /// <summary>
        /// Cigar logic 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Cigar()
        {
            var model = await cigarService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Cutter()
        {
            var model = await cutterService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Cigarillo()
        {
            var model = await cigarilloService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CigarPocketCase()
        {
            var model = await cigarCaseService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Lighter()
        {
            var model = await lighterService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Humidor()
        {
            var model = await humidorsService.GetAllAsync();

            return View(model);
        }
    }
}
