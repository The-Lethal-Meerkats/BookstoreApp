using BookstoreApp.Data.Contracts;

namespace BookstoreApp.Services.Implementation

{
    public class BookService
    {
        private readonly IUnitOfWork unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}

