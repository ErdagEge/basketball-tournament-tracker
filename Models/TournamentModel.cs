using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace basketball_tournament_tracker.Models
{
    public class Tournament : IValidatableObject
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Team> Teams { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                yield return new ValidationResult(
                    "End date must be on or after the start date.",
                    new[] { nameof(EndDate) });
            }
        }
    }
}
