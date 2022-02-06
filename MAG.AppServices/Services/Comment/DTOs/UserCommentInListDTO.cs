namespace MAG.AppServices
{
    public class UserCommentInListDTO
    {
        public long UserId { get; set; }
        public long GameId { get; set; }
        public string Username { get; set; }
        public string GameTitle { get; set; }
        public string Content { get; set; }
        public double Rating { get; set; }
    }
}
