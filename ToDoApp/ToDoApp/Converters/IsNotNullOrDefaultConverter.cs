using System;
using System.Globalization;
using MvvmCross.Converters;

namespace ToDoApp.Converters
{
    public class IsNotNullOrDefaultConverter: IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case string strValue:
                    return !string.IsNullOrEmpty(strValue);
                case DateTimeOffset dateTimeOffsetValue:
                    return dateTimeOffsetValue != default;
                default:
                    return value != null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
