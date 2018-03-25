using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookstoreApp.Services.Implementation
{
    public class BookService: IBookService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public List<BookViewModel> GetAllBooks()
        {
            var storedBooks = this.unitOfWork.Books
                .All()
                .ProjectTo<BookViewModel>()
                .ToList();

            return storedBooks;
        }

        public List<BookViewModel> GetBooksByTitle(string title)
        {
            var bookList = this.unitOfWork.Books
                .All()
                .Where(t => t.Title.ToLower().Contains(title.ToLower()))
                .ProjectTo<BookViewModel>()
                .ToList();

            return bookList;
        }

        public List<BookViewModel> GetBooksByAuthor(string authorName)
        {
            var bookList = this.unitOfWork.Books
                .All()
                .Where(a => a.Author.AuthorName.ToLower().Contains(authorName.ToLower()))
                .ProjectTo<BookViewModel>()
                .ToList();

            return bookList;
        }

        public List<BookViewModel> GetBooksByCategoryId(int id)
        {
            var bookList = this.unitOfWork.Books
                .All()
                .Where(cat => cat.CategoryId == id)
                .ProjectTo<BookViewModel>()
                .ToList();

            return bookList;
        }
    }
}

