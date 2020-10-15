using BlazorApp3.Shared.ViewModels;
using System.Collections.Generic;

namespace BlazorApp3.Shared.Wrappers
{
    public class Response
    {
        public List<BookViewModel> Books { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }

        public Response(List<BookViewModel> books, int pageNumber, int pageSize, int totalRecords)
        {
            Books = books;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
        }

        // Deserialization of reference types without parameterless constructor is not supported.
        public Response() { }
    }
}
