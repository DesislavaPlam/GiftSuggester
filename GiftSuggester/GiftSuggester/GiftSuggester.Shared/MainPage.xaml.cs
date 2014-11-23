using GiftSuggester.Data;
using GiftSuggester.Data.UnitOfWork;
using GiftSuggester.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GiftSuggester
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IAppData data;
        private AppDbConnection dbConnection;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            this.dbConnection = new AppDbConnection();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.

            await this.dbConnection.InitializeDatabase();
            this.data = new AppData(this.dbConnection);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var newFriend = new Friend
            {
                Id = 1,
                Name = "Gosho"
            };

            var newEvent = new Event
            {
                Type = EventType.BirthDay,
                Date = DateTime.Now,
                FriendId = 1
            };

            await this.data.Friends.Add(newFriend);
            await this.data.Events.Add(newEvent);
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = this.Text;
            StringBuilder content = new StringBuilder();
            content.AppendLine("Start");

            var result = await this.data.Friends.Find(1);
            content.AppendLine(result.Name);
            var fEvent = await this.data.Events.All();
            content.Append(fEvent.Where(ev => ev.Id == result.Id).First().Type.ToString());
            textBlock.Text = content.ToString();
        }
    }
}
