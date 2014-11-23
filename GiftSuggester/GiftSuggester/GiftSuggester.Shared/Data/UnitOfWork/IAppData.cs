namespace GiftSuggester.Data.UnitOfWork
{
    using GiftSuggester.Data.Repository;
    using GiftSuggester.Models;

    public interface IAppData
    {
        IRepository<Friend> Friends { get; }

        IRepository<Gift> Gifts { get; }

        IRepository<Event> Events { get; }

        IRepository<FriendGift> FriendsGifts { get; }
    }
}
