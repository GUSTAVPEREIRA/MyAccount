namespace MyAccount.Extensions.Pagination
{
    public abstract class PageResultBase
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
        public int resultCount { get; set; }
    }
}