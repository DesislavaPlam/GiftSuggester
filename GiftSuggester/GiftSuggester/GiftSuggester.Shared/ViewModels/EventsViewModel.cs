namespace GiftSuggester.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using GalaSoft.MvvmLight;

    using GiftSuggester.Data;
    using GiftSuggester.Data.UnitOfWork;
    using GiftSuggester.Models;

    public class EventsViewModel : ViewModelBase
    {
        private readonly AppDbConnection dbConnection = new AppDbConnection();
        private IAppData data;

        private ObservableCollection<EventViewModel> events;

        public EventsViewModel()
        {
            this.data = new AppData(dbConnection);
            this.LoadEvents();
        }

        public IEnumerable<EventViewModel> Events
        {
            get
            {
                if (this.events == null)
                {
                    this.Events = new ObservableCollection<EventViewModel>();
                }
                return this.events;
            }
            set
            {
                if (this.events == null)
                {
                    this.events = new ObservableCollection<EventViewModel>();
                }

                this.events.Clear();

                foreach (var item in value)
                {
                    this.events.Add(item);
                }
            }
        }

        public async Task LoadEvents()
        {
            var events = (await this.data.Events.All()).AsQueryable().Select(EventViewModel.FromEvent).AsEnumerable();

            this.Events = events;
        }

        public void AddEvents()
        {
            List<Event> events = new List<Event>()
            {
                new Event
                {
                    Type = EventType.Christmass,
                    Date = DateTime.Now,
                    FriendId = 2
                },
                new Event
                {
                    Type = EventType.BirthDay,
                    Date = DateTime.Now.AddHours(2),
                    FriendId = 1
                },
                new Event
                {
                    Type = EventType.NameDay,
                    Date = DateTime.Now.AddHours(-3),
                    FriendId = 1
                }
            };

            this.data.Events.Add(events[0]);
            this.data.Events.Add(events[1]);
            this.data.Events.Add(events[2]);
        }
    }
}
