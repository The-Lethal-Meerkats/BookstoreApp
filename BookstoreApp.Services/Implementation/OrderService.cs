using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookstoreApp.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public List<OrderViewModel> GetUserOrders(int userId)
        {
            var user = this.unitOfWork.Users.GetById(userId);

            var orders = this.unitOfWork.Orders
                .All()
                .ProjectTo<OrderViewModel>()
                .ToList();

            if(orders == null)
            {
                return null;
            }

            return orders.Where(x => x.Username == user.Username).ToList();
        }
    }
}
