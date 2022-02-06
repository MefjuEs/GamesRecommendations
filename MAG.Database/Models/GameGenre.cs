using System.ComponentModel.DataAnnotations.Schema;

namespace MAG.Database
{
    public class GameGenre
    {
        public long GameId { get; set; }
        public long GenreId { get; set; }
        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }
        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }
    }
}
