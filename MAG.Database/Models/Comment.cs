using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAG.Database
{
    public class Comment
    {
        public long UserId { get; set; }
        public long GameId { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public double Rating { get; set; }
        public DateTime Created { get; set; }

        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }
    }
}
