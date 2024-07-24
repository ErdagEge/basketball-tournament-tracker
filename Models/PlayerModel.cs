using MongoDB.Bson;

namespace basketball_tournament_tracker.Models
{
    public class Player
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int JerseyNumber { get; set; }
    }
}
