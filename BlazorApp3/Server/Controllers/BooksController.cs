using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BlazorApp3.Server.Data;
using BlazorApp3.Server.Extensions;
using BlazorApp3.Server.Options;
using BlazorApp3.Shared.ViewModels;
using BlazorApp3.Shared.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp3.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public BooksController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery]PageOption pageOption, [FromQuery]SortOption sortOption, [FromQuery]FilterOption filterOption)
        {
            var books = await context.Books
                .Filter(filterOption)
                .Sort(sortOption)
                .Page(pageOption)
                .ToListAsync();

            var bookViewModels = mapper.Map<List<BookViewModel>>(books);

            var totalCount = await context.Books
                .Filter(filterOption)
                .CountAsync();

            return Ok(new Response(bookViewModels, pageOption.PageNumber, pageOption.PageSize, totalCount));
        }
    }
}
