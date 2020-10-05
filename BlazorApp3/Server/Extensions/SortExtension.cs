using BlazorApp3.Server.Entities;
using BlazorApp3.Server.Options;
using System.Linq;

namespace BlazorApp3.Server.Extensions
{
    public static class SortExtension
    {
        public static IQueryable<Book> Sort(this IQueryable<Book> books, SortOption option)
        {
            switch (option.SortBy, option.Desc)
            {
                case ("id", false):
                    return books.OrderBy(b => b.BookId);

                case ("id", true):
                    return books.OrderByDescending(b => b.BookId);

                case ("title", false):
                    return books.OrderBy(b => b.Title);

                case ("title", true):
                    return books.OrderByDescending(b => b.Title);

                case ("author", false):
                    return books.OrderBy(b => b.Author);

                case ("author", true):
                    return books.OrderByDescending(b => b.Author);

                case ("publication", false):
                    return books.OrderBy(b => b.Publication);

                case ("publication", true):
                    return books.OrderByDescending(b => b.Publication);

                default:
                    return books.OrderBy(b => b.BookId);
            }
        }
    }
}
