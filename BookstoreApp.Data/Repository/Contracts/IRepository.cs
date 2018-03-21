namespace BookstoreApp.Data.Repository.Contracts
{
    public interface IRepository<T> : IReadOnlyRepository<T>
    {
        void Add(T entity);

        void Delete(T entity);

        void Delete(int id);

        void Update(T entity);
    }
}
