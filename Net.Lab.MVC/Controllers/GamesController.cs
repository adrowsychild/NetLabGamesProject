using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Net.Lab.Common.Interfaces;
using Net.Lab.DataContracts.Games;

namespace Net.Lab.MVC.Controllers
{
    [Route("[controller]/")]
    public class GamesController : Controller
    {
        private readonly ILogger<GamesController> logger;
        private readonly IGamesService gamesService;

        public GamesController(ILogger<GamesController> logger, IGamesService gamesService)
        {
            this.logger = logger;
            this.gamesService = gamesService;
        }

        public async Task<IActionResult> Index()
        {
            var allgames = gamesService.GetGames();

            // it's important to send the variable!
            return View(allgames);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(Game game)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                gamesService.CreateGame(game);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View(gamesService.GetGame(id));
        }

        [HttpPost("Edit/{id}")]
        public IActionResult Edit(int id, Game game)
        {
            try
            {
                game.Id = id;

                if (!ModelState.IsValid)
                {
                    return View();
                }

                gamesService.EditGame(id, game);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return View(gamesService.GetGame(id));
        }

        
        [HttpPost("Delete/{id}")]
        public IActionResult Delete(int id, Game game)
        {
            try
            {
                gamesService.DeleteGame(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}