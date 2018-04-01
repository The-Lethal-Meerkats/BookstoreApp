using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreApp.Models;
using FluentValidation;

namespace BookstoreApp.Services.Validation
{
    class OrderStatusValidator : AbstractValidator<OrderStatus>
    {
        public OrderStatusValidator()
        {
            RuleFor(orderStatus => orderStatus.OrderStatusDescription).NotEmpty();
        }
    }
}
