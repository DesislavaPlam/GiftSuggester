namespace GiftSuggester.ViewModels
{
    using System;
    using System.Linq.Expressions;

    using GalaSoft.MvvmLight;

    using GiftSuggester.Models;

    public class FriendViewModel : ViewModelBase
    {
        public static Expression<Func<Friend, FriendViewModel>> FromFriend
        {
            get
            {
                return friend =>
                    new FriendViewModel
                    {
                        Id = friend.Id,
                        Name = friend.Name,
                        Avatar = friend.Avatar
                    };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Avatar { get; set; }
    }
}
