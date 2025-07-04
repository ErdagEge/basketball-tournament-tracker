﻿using Microsoft.AspNetCore.Mvc;
using basketball_tournament_tracker.Models;
using basketball_tournament_tracker.Services;
using MongoDB.Driver;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace basketball_tournament_tracker.Controllers
{
    public class TeamController : Controller
    {
        private readonly IDatabaseService _databaseService;
        private readonly ILogger<TeamController> _logger;

        public TeamController(IDatabaseService databaseService, ILogger<TeamController> logger)
        {
            _databaseService = databaseService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Create()
        {
            _logger.LogInformation("GET Create action called.");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeamViewModel teamViewModel)
        {
            _logger.LogInformation("POST Create action called.");
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Model state is valid.");
                var team = new Team { Name = teamViewModel.Name };
                await _databaseService.Teams.InsertOneAsync(team);
                _logger.LogInformation("Team inserted into database.");
                return RedirectToAction("Index");
            }

            _logger.LogInformation("Model state is invalid.");
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    _logger.LogError("Error in {Key}: {ErrorMessage}", state.Key, error.ErrorMessage);
                }
            }

            return View(teamViewModel);
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("GET Index action called.");
            var teamsCursor = await _databaseService.Teams.FindAsync(t => true);
            var teams = await teamsCursor.ToListAsync();
            var playersCursor = await _databaseService.Players.FindAsync(p => true);
            var players = await playersCursor.ToListAsync();

            foreach (var team in teams)
            {
                team.Players = players.Where(p => p.Team == team.Name).ToList();
            }

            return View(teams);
        }
    }
}
