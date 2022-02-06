using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MAG.Database
{
    public class Game
    {
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime ReleaseYear { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Producer { get; set; }
        public double AverageRating { get; set; }
        public int NumberOfVotes { get; set; }
        public string Image { get; set; }
    
        public virtual List<GameGenre> GameGenres { get; set; }
        public virtual List<GamePlatform> GamePlatforms { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
