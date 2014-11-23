using System;
using System.Collections.Generic;
using System.Text;
using GiftSuggester.Models;

namespace GiftSuggester.ViewModels
{
    public class FriendsViewModel
    {
        private List<Friend> data;

        public FriendsViewModel()
        {
            data = new MockDB.MockFriendsData().Friends;
        }
    }
}
