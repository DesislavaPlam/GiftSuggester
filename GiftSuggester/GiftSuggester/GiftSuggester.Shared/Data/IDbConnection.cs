namespace GiftSuggester.Data
{
    using System;
    using System.Threading.Tasks;

    public interface IDbConnection
    {
        Task InitializeDatabase();
    }
}
