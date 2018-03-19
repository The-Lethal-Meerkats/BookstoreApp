using System.Linq;

namespace BookstoreApp.Data.Repository.Contracts
{
    public interface IReadOnlyRepository<TEntity>
    {
        IQueryable<TEntity> All();

        TEntity GetById(object id);
    }
}
