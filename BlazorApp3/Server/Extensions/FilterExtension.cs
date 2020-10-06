﻿using BlazorApp3.Server.Entities;
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
                    if (option.FilterValue == "all")
                    {
                        return books;
                    }
                    return books.Where(b => b.Author == option.FilterValue);

                case "publication":
                    return books.Where(b => int.Parse(option.FilterValue) <= b.Publication && b.Publication < int.Parse(option.FilterValue) + 10);

                default:
                    return books;
            }
        }

        public static IQueryable<Book> FilterByAuthor(this IQueryable<Book> books, FilterByAuthorOption option)
        {
            return option.Author switch
            {
                "all" => books,
                _ => books.Where(b => b.Author == option.Author),
            };
        }

        public static IQueryable<Book> FilterByPublication(this IQueryable<Book> books, FilterByPublicationOption option)
        {
            return option.Publication switch
            {
                "all" => books,
                _ => books.Where(b => int.Parse(option.Publication) <= b.Publication && b.Publication < int.Parse(option.Publication) + 10),
            };
        }
    }
}
