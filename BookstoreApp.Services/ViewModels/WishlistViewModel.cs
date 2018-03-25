using AutoMapper;
using BookstoreApp.Models;
using BookstoreApp.Services.AutoMapper.Mapping;
using System.Collections.Generic;

namespace BookstoreApp.Services.ViewModels
{
    public class WishlistViewModel: IMapFrom<Wishlist>, IHaveCustomMappings
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Wishlist, WishlistViewModel>()
                .ForMember(d => d.Username, opt => opt.MapFrom(w => w.User.Username))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(w => w.User.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(w => w.User.LastName))
                .ForMember(d => d.Books, opt => opt.MapFrom(w => w.Books));
        }
    }
}
