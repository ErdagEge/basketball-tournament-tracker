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
        public async Task<IActionResult> Create()
        {
            var teamsCursor = await _databaseService.Teams.FindAsync(t => true);
            var teams = await teamsCursor.ToListAsync();
            ViewBag.Teams = teams;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Player player)
        {
            if (ModelState.IsValid)
            {
                await _databaseService.Players.InsertOneAsync(player);
                return RedirectToAction("Index");
            }
            var teamsCursor = await _databaseService.Teams.FindAsync(t => true);
            var teams = await teamsCursor.ToListAsync();
            ViewBag.Teams = teams;
            return View(player);
        }

        public async Task<IActionResult> Index()
        {
            var playersCursor = await _databaseService.Players.FindAsync(p => true);
            var players = await playersCursor.ToListAsync();
            return View(players);
        }
    }
}
