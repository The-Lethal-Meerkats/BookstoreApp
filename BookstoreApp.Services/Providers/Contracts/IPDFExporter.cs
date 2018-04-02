using System.Collections.Generic;
using BookstoreApp.Services.ViewModels;

namespace BookstoreApp.Services.Providers.Contracts
{
    public interface IPDFExporter
    {
        void ExportOrders(IEnumerable<OrderViewModel> orders);
    }
}
