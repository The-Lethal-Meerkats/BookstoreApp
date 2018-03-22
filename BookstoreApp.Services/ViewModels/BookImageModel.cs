using AutoMapper;
using BookstoreApp.Models;
using BookstoreApp.Services.AutoMapper.Mapping;
using System;

namespace BookstoreApp.Services.ViewModels
{
    public class OrderViewModel: IMapFrom<Order>, IHaveCustomMappings
    {
        public DateTime ReceivedOrderTime { get; set; }

        public DateTime? OrderCompletedTime { get; set; }

        public string PhoneNumber { get; set; }

        public string Username { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Order, OrderViewModel>().ForMember(d => d.Username, opt => opt.MapFrom(s => s.User.Username));
        }
    }
}
