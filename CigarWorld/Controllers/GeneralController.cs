using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CigarWorld.Controllers
{
    [Authorize]
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
                AshtrayType = await ashtrayService.GetTypesAsync()
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

        public async Task<IActionResult> AddToCollection(int ashtrayId)
        {

            try
            {
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await ashtrayService.AddAshtrayToCollectionAsync(ashtrayId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(Cigar));
        }

        /// <summary>
        /// Cigar logic 
        /// </summary>
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


        /// <summary>
        /// Cutter logic 
        /// </summary>

        [HttpGet]
        public async Task<IActionResult> Cutter()
        {
            var model = await cutterService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddCutter()
        {
            var model = new AddCutterViewModel()
            {
                CutterTypes = await cutterService.GetTypesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCutter(AddCutterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await cutterService.AddCutterAsync(model);

                return RedirectToAction(nameof(Cutter));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

        /// <summary>
        /// Cigarillo logic 
        /// </summary>

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

        /// <summary>
        /// CigarPocketCase logic 
        /// </summary>

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

        /// <summary>
        /// Lighter logic 
        /// </summary>

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


        /// <summary>
        /// Humidor logic 
        /// </summary>

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
