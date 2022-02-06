using System;
using System.Collections.Generic;

namespace MAG.AppServices
{
    public class GameInListDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseYear { get; set; }
        public double AverageRating { get; set; }
        public FileDTO Image { get; set; }
        public string ImageName { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Platforms { get; set; }
    }
}
