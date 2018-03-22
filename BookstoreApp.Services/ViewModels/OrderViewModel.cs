using AutoMapper;
using BookstoreApp.Models;
using BookstoreApp.Services.AutoMapper.Mapping;
using System;
using System.Collections.Generic;

namespace BookstoreApp.Services.ViewModels
{
    public class OrderViewModel: IMapFrom<Order>, IHaveCustomMappings
    {
        public DateTime ReceivedOrderTime { get; set; }

        public DateTime? OrderCompletedTime { get; set; }

        public string PhoneNumber { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Order, OrderViewModel>()
                .ForMember(d => d.Username, opt => opt.MapFrom(s => s.User.Username))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.User.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.User.LastName))
                .ForMember(d => d.Books, opt => opt.MapFrom(s => s.Books));
        }
    }
}
