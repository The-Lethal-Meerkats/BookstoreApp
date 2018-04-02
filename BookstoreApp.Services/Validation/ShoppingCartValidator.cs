using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreApp.Models;
using FluentValidation;

namespace BookstoreApp.Services.Validation
{
    class ShoppingCartValidator : AbstractValidator<ShoppingCart>
    {
        public ShoppingCartValidator()
        {
            RuleFor(shoppingCart => shoppingCart.ShoppingCartStatusId).NotEmpty();
            RuleFor(shoppingCart => shoppingCart.UserId).NotEmpty();
        }
    }
}
