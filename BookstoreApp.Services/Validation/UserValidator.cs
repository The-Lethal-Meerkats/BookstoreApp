using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreApp.Models;
using BookstoreApp.Models.Accounts;
using FluentValidation;

namespace BookstoreApp.Services.Validation
{
    class UserValidator : AbstractValidator<BookstoreUser>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName).NotEmpty();
            RuleFor(user => user.LastName).NotEmpty();
            RuleFor(user => user.Email).EmailAddress();
            RuleFor(user => user.PhoneNumber).NotEmpty();
            RuleFor(user => user.UserAddress).NotEmpty();
        }
    }
}
