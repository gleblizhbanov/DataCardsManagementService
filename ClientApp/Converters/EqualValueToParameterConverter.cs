using System;
using System.Globalization;
using System.Windows.Data;

namespace ClientApp.Converters
{
    public class EqualValueToParameterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
            {
                return parameter is null;
            }

            if (parameter is null)
            {
                return false;
            }

            return value.ToString() == parameter.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
            {
                return parameter is null;
            }

            if (parameter is null)
            {
                return false;
            }

            return value.ToString() == parameter.ToString();
        }
    }
}
