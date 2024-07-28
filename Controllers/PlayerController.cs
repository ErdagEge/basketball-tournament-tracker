using basketball_tournament_tracker.Models;
using basketball_tournament_tracker.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basketball_tournament_tracker.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IDatabaseService _databaseService;

        public PlayerController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var teams = _databaseService.Teams.Find(t => true).ToList();
            ViewBag.Teams = teams;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                _databaseService.Players.InsertOne(player);
                return RedirectToAction("Index");
            }
            var teams = _databaseService.Teams.Find(t => true).ToList();
            ViewBag.Teams = teams;
            return View(player);
        }

        public IActionResult Index()
        {
            var players = _databaseService.Players.Find(p => true).ToList();
            return View(players);
        }
    }
}
