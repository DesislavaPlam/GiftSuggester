using System;
using System.Collections.Generic;
using System.Text;
using GiftSuggester.Models;

namespace GiftSuggester.ViewModels
{
    public class FriendsViewModel : ViewModelBase
    {
        private const string DefaultDisplayName = "No name";
        private List<Friend> data;

        public String DisplayName { get; set; }

        public FriendsViewModel() :
            this(DefaultDisplayName)
        {

        }

        public FriendsViewModel(string name)
        {
            this.DisplayName = name;
        }
    }
}
