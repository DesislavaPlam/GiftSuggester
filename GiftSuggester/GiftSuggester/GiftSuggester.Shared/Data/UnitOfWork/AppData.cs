namespace GiftSuggester.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using SQLite;

    using GiftSuggester.Data.Repository;
    using GiftSuggester.Models;

    public class AppData : IAppData
    {
        private readonly IDictionary<Type, object> repositories = new Dictionary<Type, object>();
        private readonly SQLiteAsyncConnection dbConnection;

        public AppData()
            : this(new AppDbConnection())
        {
        }

        public AppData(SQLiteAsyncConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public IRepository<Friend> Friends
        {
            get { return this.GetRepository<Friend>(); }
        }

        public IRepository<Gift> Gifts
        {
            get { return this.GetRepository<Gift>(); }
        }

        public IRepository<Event> Events
        {
            get { return this.GetRepository<Event>(); }
        }

        public IRepository<FriendGift> FriendsGifts
        {
            get { return this.GetRepository<FriendGift>(); }
        }

        private IRepository<T> GetRepository<T>() where T : class, IBaseEntity, new()
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var repository = new Repository<T>(this.dbConnection);

                this.repositories.Add(typeof(T), repository);
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}
