using CigarWorld.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CigarWorld.Areas.Admin.Controllers
{
    public class CigarController : AdminController
    {
        private readonly ICigarService cigarService;

        public CigarController(ICigarService _cigarService)
        {
            cigarService = _cigarService;
        }


        //[HttpGet]
        //public async Task<IActionResult> Cigar()
        //{
        //    var model = await cigarService.GetAllCigarsAsync();

        //    return View(model);

        //}
    }
}
