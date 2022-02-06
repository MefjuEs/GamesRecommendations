namespace MAG.AppServices
{
    public class InsertUpdateCommentDTO
    {
        public long UserId { get; set; }
        public long GameId { get; set; }
        public string Content { get; set; }
        public double Rating { get; set; }
        public int CommentContentMaxLength { get; internal set; }
    }
}
