using MongoDB.Bson;
using System.Numerics;

namespace basketball_tournament_tracker.Models
{
    public class Team
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }
    }
}
