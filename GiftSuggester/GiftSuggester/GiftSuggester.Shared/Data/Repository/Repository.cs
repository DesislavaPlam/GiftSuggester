namespace GiftSuggester.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SQLite;

    public class Repository<T> : IRepository<T> where T : class, IBaseEntity, new()
    {
        private SQLiteAsyncConnection dbConnection;

        public Repository(SQLiteAsyncConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public async Task<List<T>> All()
        {
            return await this.dbConnection.Table<T>().ToListAsync();
        }

        public async Task<T> Find(object id)
        {
            return await this.dbConnection.FindAsync<T>(id);
        }

        public async Task Add(T entity)
        {
            await this.dbConnection.InsertAsync(entity);
        }

        public async Task Update(T entity)
        {
            await this.dbConnection.UpdateAsync(entity);
        }

        public async Task Delete(object id)
        {
            await this.Delete(this.Find(id));
        }

        public async Task Delete(T entity)
        {
            await this.dbConnection.DeleteAsync(entity);
        }
    }
}
