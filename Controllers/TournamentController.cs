using Microsoft.AspNetCore.Mvc;
using basketball_tournament_tracker.Models;
using basketball_tournament_tracker.Services;
using MongoDB.Driver;

namespace basketball_tournament_tracker.Controllers
{
    public class TournamentController : Controller
    {
        private readonly IDatabaseService _databaseService;

        public TournamentController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                _databaseService.Tournaments.InsertOne(tournament);
                return RedirectToAction("Index");
            }
            return View(tournament);
        }

        public IActionResult Index()
        {
            var tournaments = _databaseService.Tournaments.Find(t => true).ToList();
            return View(tournaments);
        }
    }
}
