using Microsoft.AspNetCore.Mvc;
using basketball_tournament_tracker.Models;
using basketball_tournament_tracker.Services;
using MongoDB.Driver;

namespace basketball_tournament_tracker.Controllers
{
    public class TeamController : Controller
    {
        private readonly IDatabaseService _databaseService;

        public TeamController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                _databaseService.Teams.InsertOne(team);
                return RedirectToAction("Index");
            }
            return View(team);
        }

        public IActionResult Index()
        {
            var teams = _databaseService.Teams.Find(t => true).ToList();
            return View(teams);
        }
    }
}
