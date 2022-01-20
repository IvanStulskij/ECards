using System;
using System.Globalization;
using System.Windows.Data;

namespace ECards.Converters
{
    public class EventConverter : IMultiValueConverter
    {
        private const int Name = 0;
        private const int Start = 1;
        private const int End= 2;
        private const int Description = 3;
        private const int ImagePath = 4;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return Tuple.Create(
                values[Name].ToString(), 
                System.Convert.ToDateTime(values[Start]),
                System.Convert.ToDateTime(values[End]), 
                values[Description].ToString(),
                values[ImagePath].ToString());
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[0];
        }
    }
}
