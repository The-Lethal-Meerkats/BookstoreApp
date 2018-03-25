using AutoMapper;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.ViewModels;
using System.Collections.Generic;

namespace BookstoreApp.Client.Controllers
{
    public class OrderController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
        }

        public List<OrderViewModel> GetUserOrders(int userId)
        {
            var orders = this.orderService.GetUserOrders(userId);

            return orders;
        }
    }
}
