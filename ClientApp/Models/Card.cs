using ClientApp.Utils;
using System.Windows.Media.Imaging;

namespace ClientApp.Models
{
    public class Card
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public BitmapImage BitmapImage => Converter.ConvertToBitmapImage(Image);
    }
}
