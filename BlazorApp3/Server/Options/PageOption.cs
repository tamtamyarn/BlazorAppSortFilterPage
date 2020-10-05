namespace BlazorApp3.Server.Options
{
    public class PageOption
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PageOption()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }

        public PageOption(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize < 10 ? 10 : pageSize;
        }
    }
}
