using BookstoreApp.Models;
using System.Collections.Generic;

namespace BookstoreApp.Services.Contracts
{
    public interface IOrderService
    {
        IList<Order> GetUserOrders(int userId);
    }
}
