using BookstoreApp.Data;
using System.Data.Entity;
using BookstoreApp.DAL.Repository.Contracts;
using System.Linq;

namespace BookstoreApp.DAL.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal IBookstoreContext context;
        internal DbSet<TEntity> dbSet;



        public GenericRepository(IBookstoreContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);

            context.Entry(entityToUpdate)
                .State = EntityState.Modified;
        }

        public IQueryable<TEntity> All
        {
            get
            {
                return this.dbSet;
            }
        }
    }
}
