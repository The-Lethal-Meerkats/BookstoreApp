using System;
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
            if (userId < 1)
            {
                throw new ArgumentOutOfRangeException("UserID has to be equal or bigger than one.");
            }
            var ordersModel = this.unitOfWork.Orders
                .All()
                .Where(or => or.UserId == userId)
                .ProjectTo<OrderViewModel>()
                .ToList();

            if (ordersModel == null)
            {
                return null;
            }

            return ordersModel;
        }
    }
}
