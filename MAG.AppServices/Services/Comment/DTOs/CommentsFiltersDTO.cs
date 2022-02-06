namespace MAG.AppServices
{
    public class CommentsFiltersDTO : BaseFilter
    {
        public long? UserId { get; set; }
        public long? GameId { get; set; }
    }
}
