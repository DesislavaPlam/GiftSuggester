using GiftSuggester.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace GiftSuggester.Views
{
    public sealed partial class FriendsPageContent : UserControl
    {
        public FriendsPageContent()
        {
            this.InitializeComponent();

            this.DataContext = new FriendsViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as FriendsViewModel).AddFriends();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            (this.DataContext as FriendsViewModel).LoadFriends();
        }
    }
}
