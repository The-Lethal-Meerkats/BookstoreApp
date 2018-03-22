using System;
using System.Collections.Generic;
using System.Linq;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Services.Contracts;

namespace BookstoreApp.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IList<Order> GetUserOrders(int userId)
        {
            var user = this.unitOfWork.Users.GetById(userId);

            var orders = this.unitOfWork.Orders.All().ToList();

            if(orders == null)
            {
                return null;
            }

            return orders;
        }
    }
}
