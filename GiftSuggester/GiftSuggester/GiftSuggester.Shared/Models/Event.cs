﻿namespace GiftSuggester.Models
{
    using SQLite;
    using System;
    using System.Collections.Generic;
    using System.Text;

    using GiftSuggester.Data;

    [Table("Events")]
    public class Event : IBaseEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public EventType Type { get; set; }

        [NotNull]
        public DateTime Date { get; set; }

        public int FriendId { get; set; }
    }
}
