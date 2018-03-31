using AutoMapper;
using BookstoreApp.Models;
using BookstoreApp.Services.AutoMapper.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Services.ViewModels
{
    public class BookImageViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Book, BookImageViewModel>()
                .ForMember(d => d.Author, opt => opt.MapFrom(s => s.Author.AuthorName))
                .ForMember(d => d.Image, opt => opt.MapFrom(s => Convert.ToBase64String(s.BookImage.Image)));
        }
    }
}
