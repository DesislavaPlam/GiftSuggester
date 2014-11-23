namespace GiftSuggester.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using GiftSuggester.Data;
    using GiftSuggester.Data.UnitOfWork;
    using GiftSuggester.Models;

    public class EventsViewModel
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

        public void Add()
        {
            this.data.Events.Add(
                    new Event
                    {
                        Type = EventType.Christmass,
                        Date = DateTime.Now,
                        FriendId = 1
                    });

            this.data.Events.Add(
                    new Event
                    {
                        Type = EventType.BirthDay,
                        Date = DateTime.Now.AddHours(2),
                        FriendId = 1
                    });

            this.data.Events.Add(
                    new Event
                    {
                        Type = EventType.NameDay,
                        Date = DateTime.Now.AddHours(-3),
                        FriendId = 1
                    });
        }

        public async Task LoadEvents()
        {
            var events = (await this.data.Events.All()).AsEnumerable();

            this.Events = events.AsQueryable().Select(EventViewModel.FromEvent);
        }

        public string EventName
        {
            get
            {
                if (this.Events.Count() == 0)
                {
                    return "No items";
                }
                return this.Events.FirstOrDefault().Type;
            }
        }
    }
}
