using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.DAL.Repository.Contracts
{
    public interface IReadOnlyRepository<TEntity>
    {
        IQueryable<TEntity> All { get; }
        TEntity GetById(object id);
    }
}
