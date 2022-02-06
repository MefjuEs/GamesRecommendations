using System;

namespace MAG.AppServices
{
    public class GameFiltersDTO : BaseFilter
    {
        public string Title { get; set; }
        public DateTime? ReleaseYearFrom { get; set; }
        public DateTime? ReleaseYearTo { get; set; }
        public double? AvgRatingFrom { get; set; }
        public double? AvgRatingTo { get; set; }
        public long? GenreId { get; set; }
        public long? PlatformId { get; set; }
    }
}
