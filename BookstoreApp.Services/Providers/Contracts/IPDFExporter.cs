using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreApp.Services.ViewModels;

namespace BookstoreApp.Services.Providers.Contracts
{
    interface IPDFExporter
    {
        void ExportOrders(IEnumerable<OrderViewModel> orders);
    }
}
