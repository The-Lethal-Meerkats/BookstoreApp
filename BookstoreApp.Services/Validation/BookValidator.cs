using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreApp.Models;
using FluentValidation;

namespace BookstoreApp.Services.Validation
{
    class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(book => book.Price).NotEmpty();
            RuleFor(book => book.Author).NotEmpty();
            RuleFor(book => book.BookImage).NotEmpty();
            RuleFor(book => book.Category).NotEmpty();
            RuleFor(book => book.CategoryId).NotEmpty();
            
        }
    }
}
