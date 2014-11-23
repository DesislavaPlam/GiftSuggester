namespace GiftSuggester.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Text;

    using GiftSuggester.Models;
    using GiftSuggester.Data.UnitOfWork;
    using GiftSuggester.Data;

    public class EventViewModel
    {
        private IAppData data;

        public static Expression<Func<Event, EventViewModel>> FromEvent
        {
            get
            {
                return ev => new EventViewModel()
                {
                    Type = GetType(ev.Type),
                    Date = ev.Date.ToString(),
                    // FriendName = this.data.Friends.Find(ev.FriendId).
                };
            }
        }

        public EventViewModel()
        {
            this.data = new AppData(new AppDbConnection());
        }

        public string Type { get; set; }

        public string Date { get; set; }

        public string FriendName { get; set; }

        private static string GetType(EventType type)
        {
            switch (type)
            {
                case EventType.BirthDay:
                    return "Birth day";
                case EventType.NameDay:
                    return "Name day";
                case EventType.Christmass:
                    return "Christmass";
                case EventType.Anniversary:
                    return "Anniversary";
                case EventType.Other:
                    return "Other";
                default:
                    return "Non";
            }
        }
    }
}
