using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Data.Repository.Contracts
{
    public interface IRepository<TEntity> :IReadOnlyRepository<TEntity>
    {
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void Delete(object id);
        void Update(TEntity entity);
    }
}
