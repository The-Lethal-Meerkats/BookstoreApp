using BookstoreApp.Services.ViewModels;
using System.Collections.Generic;

namespace BookstoreApp.Services.Contracts
{
    public interface IOrderService
    {
        List<OrderViewModel> GetUserOrders(int userId);

        int PlaceUserOrder(int userId);
    }
}
