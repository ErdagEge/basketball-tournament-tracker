using Microsoft.AspNetCore.Mvc;
using basketball_tournament_tracker.Models;
using basketball_tournament_tracker.Services;
using MongoDB.Driver;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Create(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                await _databaseService.Tournaments.InsertOneAsync(tournament);
                return RedirectToAction("Index");
            }
            return View(tournament);
        }

        public async Task<IActionResult> Index()
        {
            var tournamentsCursor = await _databaseService.Tournaments.FindAsync(t => true);
            var tournaments = await tournamentsCursor.ToListAsync();
            return View(tournaments);
        }
    }
}
