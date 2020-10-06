using BlazorApp3.Server.Entities;
using BlazorApp3.Server.Options;
using System.Linq;

namespace BlazorApp3.Server.Extensions
{
    public static class FilterExtension
    {
        public static IQueryable<Book> Filter(this IQueryable<Book> books, FilterOption option)
        {
            return books
                .FilterByAuthor(option.Author)
                .FilterByPublication(option.Publication);
        }

        public static IQueryable<Book> FilterByAuthor(this IQueryable<Book> books, string author)
        {
            return author switch
            {
                "all" => books,
                _ => books.Where(b => b.Author == author),
            };
        }

        public static IQueryable<Book> FilterByPublication(this IQueryable<Book> books, string publication)
        {
            return publication switch
            {
                "all" => books,
                _ => books.Where(b => int.Parse(publication) <= b.Publication && b.Publication < int.Parse(publication) + 10),
            };
        }
    }
}
