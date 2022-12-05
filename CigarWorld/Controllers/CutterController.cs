﻿using CigarWorld.Contracts;
using CigarWorld.Models.AddModels;
using CigarWorld.Models.DetailsModels;
using CigarWorld.Models.EditViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CigarWorld.Controllers
{

    public class CutterController : Controller
    {
        private readonly ICutterService cutterService;

        public CutterController(ICutterService _cutterService)
        {
            cutterService = _cutterService;
        }

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

        public async Task<IActionResult> AddFavoriteCutter(int cutterId)
        {
            try
            {
                var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await cutterService.AddFavoriteCutterAsync(cutterId, userId);
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
                var curUser = this.User.Identity.Name;

                var model = cutterService.GetDetailsAsync(Id, curUser).Result;
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Details(CutterDetailsViewModel targetCutter)
        {
            var curUser = this.User.Identity.Name;

            cutterService.AddReview(targetCutter, curUser);

            return RedirectToAction("Details", "Cutter", new { id = targetCutter.Id });
        }

        public async Task<IActionResult> RemoveFromDataBase(int cutterId)
        {
            await cutterService.RemoveFromDatabaseAsync(cutterId);

            return RedirectToAction("Cutter", "Cutter");
        }

        public async Task<IActionResult> RemoveFromCollection(int cutterId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await cutterService.RemoveFromFavoritesAsync(cutterId, userId);

            return RedirectToAction("MyCollection", "MyProfile");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var targetAshtary = await cutterService.GetInformationForCutter(Id);



            var model = new EditCutterViewModel()
            {
                Id = Id,
                Brand = targetAshtary.Brand,
                Comment = targetAshtary.Comment,
                CountryOfManufacturing = targetAshtary.CountryOfManufacturing,
                CutterTypes = targetAshtary.CutterTypes,
                ImageUrl = targetAshtary.ImageUrl,
                TypeId = targetAshtary.TypeId
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(int Id, EditCutterViewModel targetCutter)
        {
            cutterService.EditCutterInformation(targetCutter);

            return RedirectToAction("Cutter", "Cutter");
        }

        public IActionResult DeleteComment(int ReviewId)
        {
            var targetCutterId = cutterService.DeleteReview(ReviewId);

            return RedirectToAction("Details", "Cutter", new { id = targetCutterId });
        }
    }
}
