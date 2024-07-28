using System.ComponentModel.DataAnnotations;

namespace basketball_tournament_tracker.Models
{
    public class TeamViewModel
    {
        [Required(ErrorMessage = "Team name is required")]
        public string Name { get; set; }
    }
}