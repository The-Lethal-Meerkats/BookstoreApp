using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.ViewModels;
using System;
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

        public BookImageViewModel GetBookById(int id)
        {
            var book = this.unitOfWork.Books.GetById(id);

            if (book == null)
            {
                return null;
            }

            var bookModel = this.mapper.Map<BookImageViewModel>(book);

            return bookModel;
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
            if (title == null)
            {
                throw new ArgumentNullException("Book's title should not be null.");
            }

            if (title.Length < 2)
            {
                throw new ArgumentOutOfRangeException("Title's length should be at least two symbols long.");
            }

            var bookList = this.unitOfWork.Books
                .All()
                .Where(t => t.Title.ToLower().Contains(title.ToLower()))
                .ProjectTo<BookViewModel>()
                .ToList();

            return bookList;
        }

        public List<BookViewModel> GetBooksByAuthor(string authorName)
        {
            if (authorName == null)
            {
                throw new ArgumentNullException("Author's name should not be null.");
            }

            if (authorName.Length < 2)
            {
                throw new ArgumentOutOfRangeException("Author's name length should be at least two symbols long.");
            }

            var bookList = this.unitOfWork.Books
                .All()
                .Where(a => a.Author.AuthorName.ToLower().Contains(authorName.ToLower()))
                .ProjectTo<BookViewModel>()
                .ToList();

            return bookList;
        }

        public List<BookViewModel> GetBooksByCategoryId(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException("Category ID should be equal or bigger than 1.");
            }

            var bookList = this.unitOfWork.Books
                .All()
                .Where(cat => cat.CategoryId == id)
                .ProjectTo<BookViewModel>()
                .ToList();

            return bookList;
        }
    }
}

