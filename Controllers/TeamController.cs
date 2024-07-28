using Microsoft.AspNetCore.Mvc;
using basketball_tournament_tracker.Models;
using basketball_tournament_tracker.Services;
using MongoDB.Driver;
using Microsoft.Extensions.Logging;

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
        public IActionResult Create(TeamViewModel teamViewModel)
        {
            _logger.LogInformation("POST Create action called.");
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Model state is valid.");
                var team = new Team { Name = teamViewModel.Name };
                _databaseService.Teams.InsertOne(team);
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

        public IActionResult Index()
        {
            _logger.LogInformation("GET Index action called.");
            var teams = _databaseService.Teams.Find(t => true).ToList();
            return View(teams);
        }
    }
}
