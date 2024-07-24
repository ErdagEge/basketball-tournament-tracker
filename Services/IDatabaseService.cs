using MongoDB.Driver;
using basketball_tournament_tracker.Models;
using System.Numerics;

namespace basketball_tournament_tracker.Services
{
    public interface IDatabaseService
    {
        IMongoCollection<Tournament> Tournaments { get; }
        IMongoCollection<Team> Teams { get; }
        IMongoCollection<Player> Players { get; }
    }
}
