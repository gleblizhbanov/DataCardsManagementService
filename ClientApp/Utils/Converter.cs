using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace ClientApp.Utils
{
    public static class Converter
    {
        public static byte[] ConvertToByteArray(BitmapImage image)
        {
            throw new NotImplementedException();
        }

        public static BitmapImage ConvertToBitmapImage(byte[] array)
        {
            if (array is null)
            {
                return null;
            }

            var bitmapImage = new BitmapImage();
            var arr = new byte[array.Length - 78];
            Array.Copy(array, 78, arr, 0, arr.Length);
            using (var memoryStream = new MemoryStream(arr))
            {
                bitmapImage.BeginInit();
                bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.UriSource = null;
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.EndInit();
            }

            bitmapImage.Freeze();
            return bitmapImage;
        }
    }
}
