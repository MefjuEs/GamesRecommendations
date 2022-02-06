using System;
using System.Collections.Generic;

namespace MAG.AppServices
{
    public class GameDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseYear { get; set; }
        public string Publisher { get; set; }
        public string Producer { get; set; }
        public double AverageRating { get; set; }
        public int NumberOfVotes { get; set; }
        public FileDTO Image { get; set; }
        public List<GenreInGameDTO> Genres { get; set; }
        public List<PlatformInGameDTO> Platforms { get; set; }
    }
}
