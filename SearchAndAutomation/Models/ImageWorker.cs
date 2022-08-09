using System;
using SAAlib;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace SearchAndAutomation.Models
{
    internal class ImageWorker
    {
        public static BitmapImage GetScreenShotFromHandler(IntPtr mainHandler)
        {
            var winRect = new Struct.Rect();
            WinFunc.GetWindowRect(mainHandler, ref winRect);
            var winRectWidth = Math.Abs(winRect.Right - winRect.Left);
            var winRectHeight = Math.Abs(winRect.Bottom - winRect.Top);
            using (Bitmap bitmap = new Bitmap(winRectWidth, winRectHeight))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(winRect.Left, winRect.Top), Point.Empty, new System.Drawing.Size() { Height = winRectHeight, Width = winRectWidth });
                }
                // select the save location of the captured screenshot
                return BitmapToImageSource(bitmap);
            }
        }

        private static BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }
    }
}
