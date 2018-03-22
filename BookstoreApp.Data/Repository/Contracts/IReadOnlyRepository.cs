using System.Linq;

namespace BookstoreApp.Data.Repository.Contracts
{
    public interface IReadOnlyRepository<T>
    {
        IQueryable<T> All();

        T GetById(int id);
    }
}
