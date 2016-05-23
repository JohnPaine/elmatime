using System.Net;
using Android.Graphics;

namespace ImpeltechTime.Droid.Utility
{
    public class ImageHelper
    {
        public static Bitmap GetImageBitmapFromUrl (string url) {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient ()) {
                var imageBytes = webClient.DownloadData (url);
                if (imageBytes != null && imageBytes.Length > 0) {
                    imageBitmap = BitmapFactory.DecodeByteArray (imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }

        public static Bitmap GetImageBitmapFromFilePath (string fileName, int width, int height) {
            // First we get the the dimensions of the file on disk
            var options = new BitmapFactory.Options {InJustDecodeBounds = true};
            BitmapFactory.DecodeFile (fileName, options);

            // Next we calculate the ratio that we need to resize the image by
            // in order to fit the requested dimensions.
            var outHeight = options.OutHeight;
            var outWidth = options.OutWidth;
            var inSampleSize = 1;

            if (outHeight > height || outWidth > width) {
                inSampleSize = outWidth > outHeight
                                   ? outHeight/height
                                   : outWidth/width;
            }

            // Now we will load the image and have BitmapFactory resize it for us.
            options.InSampleSize = inSampleSize;
            options.InJustDecodeBounds = false;
            var resizedBitmap = BitmapFactory.DecodeFile (fileName, options);

            return resizedBitmap;
        }
    }
}