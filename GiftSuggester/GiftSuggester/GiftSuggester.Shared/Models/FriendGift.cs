namespace GiftSuggester.Models
{
    using System;
    using SQLite;

    using GiftSuggester.Data;

    public class FriendGift : IBaseEntity
    {
        public int Id { get; set; }

        public int FriendId { get; set; }

        public int GiftId { get; set; }
    }
}
