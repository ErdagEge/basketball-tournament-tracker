using MongoDB.Bson;

namespace basketball_tournament_tracker.Models
{
    public class Tournament
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Team> Teams { get; set; }
    }
}
