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

    public class FriendsViewModel : ViewModelBase
    {
        private IAppData data;

        private ObservableCollection<FriendViewModel> friends;

        public FriendsViewModel()
        {
            this.data = new AppData(new AppDbConnection());
            this.LoadFriends();
        }

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

        public async Task LoadFriends()
        {
            var friends = (await this.data.Friends.All()).AsQueryable().Select(FriendViewModel.FromFriend).AsEnumerable();

            this.Friends = friends;
        }

        public void AddFriends()
        {
            this.data.Friends.Add(new Friend { Name = "Goshko", Avatar = "Assets/default-avatar.png" });
            this.data.Friends.Add(new Friend { Name = "Peshko", Avatar = "Assets/default-avatar.png" });
        }
    }
}
