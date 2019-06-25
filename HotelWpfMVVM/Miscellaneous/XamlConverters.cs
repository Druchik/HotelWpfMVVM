using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using HotelWpfMVVM.Model;

namespace HotelWpfMVVM.Miscellaneous
{
    public class DateTimeToDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => ((DateTime)value).ToString("dd.MM.yyyy");

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => DependencyProperty.UnsetValue;
    }

    public class RoomTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (int)value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => (RoomTypes)value;
    }

    public class RoomFreeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (int)value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => (RoomsFree)value;
    }
}
