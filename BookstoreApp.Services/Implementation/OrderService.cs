using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.ViewModels;
using System.Collections.Generic;
using System.Linq;
using BookstoreApp.Models;

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

            var ordersModel = GetOrdersByUserId(userId);

            return ordersModel;
        }

        public decimal GetTotalOrderPrice(int orderId)
        {
            
            if (orderId < 1)
            {
                throw new ArgumentOutOfRangeException("orderID has to be equal or bigger than one.");
            }

            var order = GetOrderByOrderId(orderId);

            if (order == null)
            {
                throw new ArgumentNullException("Order cannot be found");
            }

            decimal totalPrice = 0;

            foreach (var book in order.Books)
            {
                totalPrice += book.Price;
            }

            return totalPrice;
        }

        public int PlaceUserOrder(int userId)
        {
            var shoppingCart = this.unitOfWork.ShoppingCarts
                .All()
                .Where(sc => sc.UserId == userId)
                .FirstOrDefault();

            if (shoppingCart == null)
            {
                return -1;
            }

            var orderToPlace = new Order()
            {
                Books = shoppingCart.Books,
                DeliveryAddress = shoppingCart.User.UserAddress,
                OrderStatusId = 1,
                PhoneNumber = shoppingCart.User.PhoneNumber,
                UserId = userId
            };

            this.unitOfWork.Orders.Add(orderToPlace);
            this.unitOfWork.ShoppingCarts.Delete(shoppingCart);

            return this.unitOfWork.SaveChanges();
        }

        private Order GetOrderByOrderId(int orderId)
        {
            var order = this.unitOfWork.Orders.GetById(orderId);

            return order;
        }

        private List<OrderViewModel> GetOrdersByUserId(int userId)
        {
            var ordersModel = this.unitOfWork.Orders
                .All()
                .Where(or => or.UserId == userId)
                .ProjectTo<OrderViewModel>()
                .ToList();

            return ordersModel;
        }
    }
}
