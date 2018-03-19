using System.Collections.Generic;
using System.Linq;
using BookstoreApp.Data.Contracts;
using BookstoreApp.Models;
using BookstoreApp.Services.Contracts;

namespace BookstoreApp.Services.Implementation

{
    public class BookService: IBookService
    {
        private readonly IUnitOfWork unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IList<Book> GetAllBooks()
        {
            return this.unitOfWork.Books.All().ToList();
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

