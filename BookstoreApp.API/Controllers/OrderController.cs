using System;
using System.Web.Mvc;
using BookstoreApp.Models.Accounts;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.Providers.Contracts;

namespace BookstoreApp.API.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private IOrderService orderService;
        private IShoppingCartService shoppingCartService;
        private IPDFExporter pdfExporter;
        private IBookstoreUserContext userContext;

        public OrderController(IOrderService orderService, IShoppingCartService shoppingCartService, 
            IPDFExporter pdfExporter, IBookstoreUserContext userContext)
        {
            this.orderService = orderService;
            this.shoppingCartService = shoppingCartService;
            this.pdfExporter = pdfExporter;
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
                return View("OrderExportFail");
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
                return View("OrderExportFail");
            }
        }

        public ActionResult ExportOrders()
        {
            try
            {
                var userId = userContext.UserId;

                var orders = this.orderService.GetUserOrders(userId);

                this.pdfExporter.ExportOrders(orders);

                return View("OrderExportSuccess");
            }
            catch (Exception)
            {
                return View("OrderExportFail");
            }
        }
    }
}
