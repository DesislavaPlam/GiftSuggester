namespace GiftSuggester.ViewModels
{
    using System;
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

    public class GiftsViewModel : ViewModelBase
    {
        private IAppData data;
        private ICommand refreshCommand;
        private ICommand addDataCommand;
        private ICommand saveCommand;

        private ObservableCollection<GiftViewModel> gifts;

        public GiftsViewModel()
        {
            this.data = new AppData(new AppDbConnection());
            this.Gift = new GiftViewModel();

            this.LoadGifts();
        }

        public GiftViewModel Gift { get; set; }

        public IEnumerable<GiftViewModel> Gifts
        {
            get
            {
                if (this.gifts == null)
                {
                    this.Gifts = new ObservableCollection<GiftViewModel>();
                }
                return this.gifts;
            }
            set
            {
                if (this.gifts == null)
                {
                    this.gifts = new ObservableCollection<GiftViewModel>();
                }

                this.gifts.Clear();

                foreach (var item in value)
                {
                    this.gifts.Add(item);
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

        private void PerformAddData()
        {
            this.AddGifts();
        }

        private void PerformRefresh()
        {
            this.LoadGifts();
        }

        private async Task LoadGifts()
        {
            var gifts = (await this.data.Gifts.All()).AsQueryable().Select(GiftViewModel.FromGift).AsEnumerable();

            this.Gifts = gifts;
        }

        private void AddGifts()
        {
            this.data.Gifts.Add(new Gift { Name = "Book", Image = "Assets/gift.png", Address = "Sofia" });
            this.data.Gifts.Add(new Gift { Name = "Barbaron", Image = "Assets/default-avatar.png", Address = "http://barbaron.bg/" });
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
            if (!string.IsNullOrWhiteSpace(this.Gift.Name))
            {
                var newGift = new Gift
                {
                    Name = this.Gift.Name,
                    Address = this.Gift.Address
                };

                this.data.Gifts.Add(newGift);

            }
        }
    }
}
