using Microsoft.AspNetCore.Mvc.ModelBinding;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace basketball_tournament_tracker.Models
{
    public class Team
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BindNever] // This will ensure the Id is not bound by the model binder
        public string Id { get; set; }

        [Required(ErrorMessage = "Team Name is required.")]
        public string Name { get; set; }
    }
}
