using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace ClientApp.Utils
{
    public static class Converter
    {
        public static byte[] ConvertToByteArray(BitmapImage image)
        {
            if (image is null)
            {
                return null;
            }

            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (var memoryStream = new MemoryStream())
            {
                encoder.Save(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public static BitmapImage ConvertToBitmapImage(byte[] array)
        {
            if (array is null)
            {
                return null;
            }

            var bitmapImage = new BitmapImage();
            using (var memoryStream = new MemoryStream(array))
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
