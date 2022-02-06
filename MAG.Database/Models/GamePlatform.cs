using System.ComponentModel.DataAnnotations.Schema;

namespace MAG.Database
{
    public class GamePlatform
    {
        public long GameId { get; set; }
        public long PlatformId { get; set; }
        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }
        [ForeignKey("PlatformId")]
        public virtual Platform Platform { get; set; }
    }
}
