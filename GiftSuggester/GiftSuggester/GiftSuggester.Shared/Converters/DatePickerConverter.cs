namespace GiftSuggester.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Windows.UI.Xaml.Data;

    public class DatePickerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return DateTime.Parse(value.ToString());
        }
    }
}
