using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreApp.Models;
using FluentValidation;

namespace BookstoreApp.Services.Validation
{
    class ShoppingCartStatusValidator : AbstractValidator<ShoppingCartStatus>
    {
        public ShoppingCartStatusValidator()
        {
            RuleFor(shoppingCartStatus => shoppingCartStatus.ShoppingCartStatusDescription).NotEmpty();
        }
    }
}
