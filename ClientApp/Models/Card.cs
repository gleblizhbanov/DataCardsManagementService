using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ClientApp.Utils;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace ClientApp.Models
{
    public class Card : INotifyPropertyChanged
    {
        private byte[] image;
        private BitmapImage bitmapImage;

        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Image
        {
            get => image ?? (bitmapImage is null ? null : Converter.ConvertToByteArray(bitmapImage));
            set
            {
                this.image = value;
                this.OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public BitmapImage BitmapImage
        {
            get => bitmapImage ?? Converter.ConvertToBitmapImage(image);
            set
            {
                this.bitmapImage = value;
                this.OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
