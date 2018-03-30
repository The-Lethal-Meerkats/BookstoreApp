using System.Data.Entity;
using System.Linq;
using BookstoreApp.Data.Repository.Contracts;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq.Expressions;

namespace BookstoreApp.Data.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private IBookstoreContext context;
        private IDbSet<T> dbSet;

        public GenericRepository(IBookstoreContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("An instance of BookstoreContext is required to use this repository.", "context");
            }

            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual IQueryable<T> All()
        {
            return this.dbSet.AsQueryable();
        }

        public virtual T GetById(int id)
        {
            return this.dbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry entry = this.context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.dbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public void AddOrUpdate(Expression<Func<T, object>> condition, T entity)
        {
            this.dbSet.AddOrUpdate(condition, entity);
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry entry = this.context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.dbSet.Attach(entity);
                this.dbSet.Remove(entity);
            }
        }

        public virtual void Delete(int id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }
    }
}
