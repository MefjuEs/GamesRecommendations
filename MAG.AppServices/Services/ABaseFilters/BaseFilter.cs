namespace MAG.AppServices
{
    public abstract class BaseFilter
    {
        public int Page { get; set; }
        public int? PageSize { get; set; }
        public string OrderBy { get; set; }
    }
}
