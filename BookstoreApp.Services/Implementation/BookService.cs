using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Services.Contracts;
using BookstoreApp.Services.ViewModels;

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

        public IList<Book> GetBookByTitle(string title)
        {
            var bookList = this.unitOfWork.Books.All().ToList();
            return bookList.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToList();
        }

        public IList<Book> GetBooksByAuthor(string authorName)
        {
            var authorListIds = new List<int>();

            foreach (var author in this.unitOfWork.Authors.All())
            {
                if(author.AuthorName.ToLower() == authorName.ToLower())
                {
                    authorListIds.Add(author.Id);
                }
            }

            return this.unitOfWork.Books.All().ToList().Where(x => authorListIds.Contains(x.AuthorId)).ToList();
        }

        public IList<Book> GetBooksByCategoryId(int id)
        {
            return this.unitOfWork.Books.All().ToList().Where(x => x.CategoryId == id).ToList();
        }
    }
}

