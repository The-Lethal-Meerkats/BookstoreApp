using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreApp.Models;
using FluentValidation;

namespace BookstoreApp.Services.Validation
{
    class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(order => order.DeliveryAddress).NotEmpty();
            RuleFor(order => order.OrderStatusId).NotEmpty();
            RuleFor(order => order.PhoneNumber).NotEmpty();
            RuleFor(order => order.UserId).NotEmpty();
        }
    }
}
