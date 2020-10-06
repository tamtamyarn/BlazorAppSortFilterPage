using BlazorApp3.Server.Entities;
using BlazorApp3.Server.Options;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp3.Server.Extensions
{
    public static class FilterExtension
    {
        public static IQueryable<Book> Filter(this IQueryable<Book> books, FilterOption option)
        {
            return books
                .FilterByAuthors(option.Authors)
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

        public static IQueryable<Book> FilterByAuthors(this IQueryable<Book> books, string authors)
        {
            switch (authors)
            {
                case "all":
                    return books;

                case null:
                    return books;

                default:
                    string[] authorList = authors.Split(",");
                    return books.Where(b => authorList.Any(a => b.Author == a));
            }
        }
    }
}
