using BlazorApp3.Server.Entities;
using BlazorApp3.Server.Options;
using System.Linq;

namespace BlazorApp3.Server.Extensions
{
    public static class FilterExtension
    {
        public static IQueryable<Book> Filter(this IQueryable<Book> books, FilterOption option)
        {
            switch (option.FilterBy)
            {
                case "author":
                    return books.Where(b => b.Author == option.FilterValue);

                case "publication":
                    return books.Where(b => int.Parse(option.FilterValue) <= b.Publication && b.Publication < int.Parse(option.FilterValue) + 10);

                default:
                    return books;
            }
        }
    }
}
