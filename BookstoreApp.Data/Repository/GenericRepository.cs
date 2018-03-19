using System.Data.Entity;
using System.Linq;
using BookstoreApp.Data.Repository.Contracts;
using System;

namespace BookstoreApp.Data.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal IBookstoreContext context;
        internal IDbSet<TEntity> dbSet;

        public GenericRepository(IBookstoreContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of IBookstoreContext is required to use this repository.", "context");
            }

            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> All()
        {
            return this.dbSet.AsQueryable();
        }

        public virtual TEntity GetById(object id)
        {
            return this.dbSet.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            this.dbSet.Attach(entityToUpdate);

            context.Entry(entityToUpdate)
                .State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = this.dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                this.dbSet.Attach(entityToDelete);
            }

            this.dbSet.Remove(entityToDelete);
        }
    }
}
