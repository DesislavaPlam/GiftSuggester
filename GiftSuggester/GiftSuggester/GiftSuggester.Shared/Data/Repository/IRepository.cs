namespace GiftSuggester.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRepository<T>
    {
        Task<List<T>> All();

        Task<T> Find(object id);

        Task Add(T entity);

        Task Update(T entity);

        Task Delete(object id);

        Task Delete(T entity);
    }
}
