using Microsoft.Extensions.Options;
using MongoDB.Driver;
using basketball_tournament_tracker.Models;
using basketball_tournament_tracker.Settings;

namespace basketball_tournament_tracker.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IMongoDatabase _database;
        private readonly ILogger<DatabaseService> _logger;

        public DatabaseService(IOptions<DatabaseSettings> settings, IMongoClient client, ILogger<DatabaseService> logger)
        {
            _database = client.GetDatabase(settings.Value.DatabaseName);
            _logger = logger;
            _logger.LogInformation("Connected to MongoDB database: {DatabaseName}", settings.Value.DatabaseName);
        }

        public IMongoCollection<Tournament> Tournaments => _database.GetCollection<Tournament>("Tournaments");
        public IMongoCollection<Team> Teams => _database.GetCollection<Team>("Teams");
        public IMongoCollection<Player> Players => _database.GetCollection<Player>("Players");
    }
}
