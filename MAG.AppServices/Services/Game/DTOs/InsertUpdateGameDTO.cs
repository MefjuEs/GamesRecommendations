using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace MAG.AppServices
{
    public class InsertUpdateGameDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseYear { get; set; }
        public string Publisher { get; set; }
        public string Producer { get; set; }
        public IFormFile File { get; set; }
        public bool UpdateImage { get; set; }
        public List<long> Genres { get; set; }
        public List<long> Platforms { get; set; }
    }
}
