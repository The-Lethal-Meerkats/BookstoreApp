using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreApp.Models;
using FluentValidation;

namespace BookstoreApp.Services.Validation
{
    class WishlistValidator : AbstractValidator<Wishlist>
    {
        public WishlistValidator()
        {
            RuleFor(wishlist => wishlist.UserId).NotEmpty();
        }
    }
}
