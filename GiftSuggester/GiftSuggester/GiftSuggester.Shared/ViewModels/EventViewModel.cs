namespace GiftSuggester.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using GalaSoft.MvvmLight;

    using GiftSuggester.Models;
    using GiftSuggester.Data.UnitOfWork;
    using GiftSuggester.Data;

    public class EventViewModel : ViewModelBase
    {
        private readonly IAppData data = new AppData(new AppDbConnection());

        private string friendName;

        public static Expression<Func<Event, EventViewModel>> FromEvent
        {
            get
            {
                return ev => new EventViewModel()
                {
                    Type = GetType(ev.Type),
                    Date = ev.Date,
                    FriendId = ev.FriendId,
                    FriendName = ""
                };
            }
        }

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

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public int FriendId { get; set; }

        public string FriendName
        {
            get
            {
                if (string.IsNullOrEmpty(this.friendName))
                {
                    this.GetFriendName(this.FriendId);
                }

                return this.friendName;
            }
            set
            {
                this.friendName = value;
                this.RaisePropertyChanged(() => this.FriendName);
            }
        }

        private async Task GetFriendName(int id)
        {
            this.FriendName = (await this.data.Friends.Find(id)).Name;
        }
    }
}
