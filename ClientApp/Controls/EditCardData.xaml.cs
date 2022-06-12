using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace ClientApp.Controls
{
    /// <summary>
    /// Interaction logic for EditCardData.xaml
    /// </summary>
    public partial class EditCardData : UserControl
    {
        public EditCardData()
        {
            InitializeComponent();
        }

        private void LoadImageButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "jpg images (*.jpg)|*.jpg"
            };

            var showResult = dialog.ShowDialog();

            if (showResult.HasValue && showResult.Value)
            {
                var card = (Models.Card)DataContext;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(dialog.FileName);
                bitmapImage.DecodePixelHeight = 200;
                bitmapImage.EndInit();
                card.BitmapImage = bitmapImage;
            }
        }
    }
}
