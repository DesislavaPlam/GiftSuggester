namespace GiftSuggester.Data
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using SQLite;
    using Windows.Storage;

    using GiftSuggester.Models;

    public class AppDbConnection : SQLiteAsyncConnection, IDbConnection
    {
        private static string dbPath = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, "GiftSuggester.db"));
        private readonly SQLiteAsyncConnection dbConnection;

        public AppDbConnection()
            : base(dbPath)
        {
            this.dbConnection = new SQLiteAsyncConnection(dbPath);
        }

        public async Task InitializeDatabase()
        {
            bool dbExists = await CheckDbAsync(dbPath);
            if (!dbExists)
            {
                await CreateDatabaseAsync();
            }
        }

        private async Task<bool> CheckDbAsync(string dbPath)
        {
            bool dbExist = true;

            try
            {
                StorageFile sf = await ApplicationData.Current.LocalFolder.GetFileAsync(dbPath);
            }
            catch (Exception)
            {
                dbExist = false;
            }

            return dbExist;
        }

        private async Task CreateDatabaseAsync()
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbPath);
            await this.dbConnection.CreateTablesAsync<Friend, Event, Gift, FriendGift>();
        }
    }
}
