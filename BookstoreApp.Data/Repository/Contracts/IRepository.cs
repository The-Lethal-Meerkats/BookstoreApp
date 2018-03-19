namespace BookstoreApp.Data.Repository.Contracts
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
    {
        void Add(TEntity entity);

        void Delete(TEntity entity);

        void Delete(object id);

        void Update(TEntity entity);
    }
}
