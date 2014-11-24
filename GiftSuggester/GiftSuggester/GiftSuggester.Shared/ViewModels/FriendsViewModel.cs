namespace GiftSuggester.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    using GiftSuggester.Data;
    using GiftSuggester.Data.UnitOfWork;
    using GiftSuggester.Models;
    using System;

    public class FriendsViewModel : ViewModelBase
    {
        private IAppData data;
        private ICommand refreshCommand;
        private ICommand addDataCommand;
        private ICommand saveCommand;

        private ObservableCollection<FriendViewModel> friends;

        public FriendsViewModel()
        {
            this.data = new AppData(new AppDbConnection());
            this.Friend = new FriendViewModel();
            this.Event = new EventViewModel();
            this.LoadFriends();
        }

        public FriendViewModel Friend { get; set; }

        public EventViewModel Event { get; set; }

        public IEnumerable<FriendViewModel> Friends
        {
            get
            {
                if (this.friends == null)
                {
                    this.Friends = new ObservableCollection<FriendViewModel>();
                }
                return this.friends;
            }
            set
            {
                if (this.friends == null)
                {
                    this.friends = new ObservableCollection<FriendViewModel>();
                }

                this.friends.Clear();

                foreach (var item in value)
                {
                    this.friends.Add(item);
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

        public ICommand Save
        {
            get
            {
                if (this.saveCommand == null)
                {
                    this.saveCommand = new RelayCommand(this.PerformSave);
                }
                return this.saveCommand;
            }
        }

        private void PerformSave()
        {
            if (!string.IsNullOrWhiteSpace(this.Friend.Name))
            {
                var newFriend = new Friend
                {
                    Name = this.Friend.Name
                };

                this.data.Friends.Add(newFriend);

                this.data.Friends.All().ContinueWith(t =>
                {
                    var newFriendId = t.Result.Last().Id;

                    var newEvent = new Event
                    {
                        Type = EventType.BirthDay,
                        Date = this.Event.Date,
                        FriendId = newFriend.Id
                    };
                    this.data.Events.Add(newEvent);
                });

            }
        }

        private void PerformAddData()
        {
            this.AddFriends();
        }

        private void PerformRefresh()
        {
            this.LoadFriends();
        }


        private async Task LoadFriends()
        {
            var friends = (await this.data.Friends.All()).AsQueryable().Select(FriendViewModel.FromFriend).AsEnumerable();

            this.Friends = friends;
        }

        private void AddFriends()
        {
            this.data.Friends.Add(new Friend { Name = "Goshko", Avatar = "Assets/default-avatar.png" });
            this.data.Friends.Add(new Friend { Name = "Peshko", Avatar = "Assets/default-avatar.png" });
        }
    }
}
