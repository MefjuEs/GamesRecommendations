namespace MAG.AppServices
{
    public class BaseReturnedListWithFilters
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int AllPages { get; set; }
        public long AllElements { get; set; }
    }
}
