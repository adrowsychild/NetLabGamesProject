using Net.Lab.Common.Interfaces;
using Net.Lab.DataContracts.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrameworkMVC.Controllers
{
    public class GamesController : Controller
    {
        IGamesService gamesService;

        public GamesController()
        {

        }

        public GamesController(IGamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        // GET: Games
        public ActionResult Index()
        {
            var result = gamesService.GetGames();

            return View(result);
        }
    }
}