using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using ClientApp.ViewModels;

namespace ClientApp.Converters
{
    public class ViewModelToDeleteButtonVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is HomeViewModel model && (model.CardsListViewModel.SelectedCards?.Count ?? 0) > 0)
            {
                return Visibility.Visible;
            }

            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
