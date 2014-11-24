namespace GiftSuggester.ViewModels
{
    using System;
    using System.Linq.Expressions;

    using GalaSoft.MvvmLight;

    using GiftSuggester.Models;

    public class GiftViewModel : ViewModelBase
    {
        public static Expression<Func<Gift, GiftViewModel>> FromGift
        {
            get
            {
                return gift =>
                    new GiftViewModel
                    {
                        Id = gift.Id,
                        Name = gift.Name,
                        Image = gift.Image,
                        Address = gift.Address
                    };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Address { get; set; }
    }
}
