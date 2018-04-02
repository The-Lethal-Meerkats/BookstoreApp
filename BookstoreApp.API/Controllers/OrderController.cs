using System;
using System.Web.Mvc;
using BookstoreApp.Models.Accounts;
using BookstoreApp.Services.Contracts;

namespace BookstoreApp.API.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService orderService;
        private IShoppingCartService shoppingCartService;
        private IBookstoreUserContext userContext;

        public OrderController(IOrderService orderService, IShoppingCartService shoppingCartService, IBookstoreUserContext userContext)
        {
            this.orderService = orderService;
            this.shoppingCartService = shoppingCartService;
            this.userContext = userContext;
        }

        public ActionResult PlaceUserOrder()
        {
            try
            {
                var userId = userContext.UserId;

                var result = this.orderService.PlaceUserOrder(userId);

                if (result > 0)
                {
                    this.shoppingCartService.RemoveShoppingCart(userId);
                }

                return View("OrderSuccess");
            }
            catch (Exception)
            {
                return View("OrderFail");
            }
        }

        public ActionResult PersonalOrders()
        {
            try
            {
                var userId = userContext.UserId;

                var orders = this.orderService.GetUserOrders(userId);

                return View(orders);
            }
            catch (Exception)
            {
                return View("OrderFail");
            }
        }
    }
}
