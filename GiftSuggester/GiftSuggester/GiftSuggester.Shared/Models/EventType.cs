namespace GiftSuggester.Models
{
    using SQLite;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public enum EventType
    {
        BirthDay = 0,
        NameDay = 1,
        Christmass = 2,
        Anniversary = 3,
        Other = 99
    }
}
