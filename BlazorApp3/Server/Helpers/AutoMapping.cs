using AutoMapper;
using BlazorApp3.Server.Entities;
using BlazorApp3.Shared.ViewModels;

namespace BlazorApp3.Server.Helpers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Book, BookViewModel>();
        }
    }
}
