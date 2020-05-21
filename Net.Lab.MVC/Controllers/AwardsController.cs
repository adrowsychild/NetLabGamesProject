using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Net.Lab.Common.Interfaces;
using Net.Lab.DAL.Exceptions;
using Net.Lab.DataContracts.Awards;

namespace Net.Lab.MVC.Controllers
{
    [Route("[controller]/")]
    public class AwardsController : Controller
    {
        private readonly ILogger<GamesController> logger;
        private readonly IAwardsService awardsService;

        public AwardsController(ILogger<GamesController> logger, IAwardsService awardsService)
        {
            this.logger = logger;
            this.awardsService = awardsService;
        }

        public async Task<IActionResult> Index()
        {
            var allAwards = awardsService.GetAwards();

            return View(allAwards);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(Award award)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                awardsService.CreateAward(award);

                return RedirectToAction(nameof(Index));
            }
            catch (InvalidAwardException)
            {
                ModelState.AddModelError("GameId", "GameId should point to the existing game.");
                return View();
            }
        }

        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View(awardsService.GetAward(id));
        }

        [HttpPost("Edit/{id}")]
        public IActionResult Edit(int id, Award award)
        {
            try
            {
                award.Id = id;

                if (!ModelState.IsValid)
                {
                    return View();
                }

                awardsService.EditAward(id, award);

                return RedirectToAction(nameof(Index));
            }
            catch (InvalidAwardException)
            {
                ModelState.AddModelError("GameId", "GameId should point to the existing game.");
                return View();
            }
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return View(awardsService.GetAward(id));
        }


        [HttpPost("Delete/{id}")]
        public IActionResult Delete(int id, Award award)
        {
            try
            {
                awardsService.DeleteAward(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}