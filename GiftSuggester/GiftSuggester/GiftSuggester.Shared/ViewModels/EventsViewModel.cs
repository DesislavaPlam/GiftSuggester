namespace GiftSuggester.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    using GiftSuggester.Data;
    using GiftSuggester.Data.UnitOfWork;
    using GiftSuggester.Models;

    public class EventsViewModel : ViewModelBase
    {
        private IAppData data;
        private ICommand refreshCommand;
        private ICommand addDataCommand;

        private ObservableCollection<EventViewModel> events;

        public EventsViewModel()
        {
            this.data = new AppData(new AppDbConnection());
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

        public ICommand Refresh
        {
            get
            {
                if (this.refreshCommand == null)
                {
                    this.refreshCommand = new RelayCommand(this.PerformRefresh);
                }
                return this.refreshCommand;
            }
        }

        public ICommand AddData
        {
            get
            {
                if (this.addDataCommand == null)
                {
                    this.addDataCommand = new RelayCommand(this.PerformAddData);
                }
                return this.addDataCommand;
            }
        }

        public async Task LoadEvents()
        {
            var events = (await this.data.Events.All())
                .AsQueryable()
                //.Where(ev => ev.Date > DateTime.Now)
                .OrderBy(ev => ev.Date)
                .Select(EventViewModel.FromEvent)
                .AsEnumerable();

            this.Events = events;
        }

        private void AddEvents()
        {
            List<Event> events = new List<Event>()
            {
                new Event
                {
                    Type = EventType.Christmass,
                    Date = DateTime.Now.AddDays(31),
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
                    Date = DateTime.Now.AddDays(3),
                    FriendId = 1
                }
            };

            this.data.Events.Add(events[0]);
            this.data.Events.Add(events[1]);
            this.data.Events.Add(events[2]);
        }

        private void PerformRefresh()
        {
            this.LoadEvents();
        }

        private void PerformAddData()
        {
            this.AddEvents();
        }
    }
}
