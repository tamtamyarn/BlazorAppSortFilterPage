using BlazorApp3.Server.Entities;
using BlazorApp3.Server.Options;
using System.Linq;

namespace BlazorApp3.Server.Extensions
{
    public static class PageExtension
    {
        public static IQueryable<Book> Page(this IQueryable<Book> books, PageOption option)
        {
            return books
                .Skip((option.PageNumber - 1) * option.PageSize)
                .Take(option.PageSize);
        }
    }
}
