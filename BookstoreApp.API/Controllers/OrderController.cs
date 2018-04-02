using System;
using System.Web.Mvc;
using BookstoreApp.Models.Accounts;
using BookstoreApp.Services.Contracts;

namespace BookstoreApp.API.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService orderService;
        private IBookstoreUserContext userContext;

        public OrderController(IOrderService orderService, IBookstoreUserContext userContext)
        {
            this.orderService = orderService;
            this.userContext = userContext;
        }

        public ActionResult PlaceUserOrder()
        {
            try
            {
                var userId = userContext.UserId;

                this.orderService.PlaceUserOrder(userId);
            }
            catch (Exception)
            {
                return View("OrderFail");
            }

            return View("OrderSuccess");
        }
    }
}
