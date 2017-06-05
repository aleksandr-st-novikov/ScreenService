using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domain
{
    public class Methods
    {
        public static void GetScreen()
        {
            using (Bitmap bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                            Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bmpScreenCapture))
                {
                    g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                     Screen.PrimaryScreen.Bounds.Y,
                                     0, 0,
                                     bmpScreenCapture.Size,
                                     CopyPixelOperation.SourceCopy);
                }
                ImageCodecInfo codecInfo = GetEncoder(ImageFormat.Jpeg);

                EncoderParameters parameters = new EncoderParameters(1);
                parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 40L);
                bmpScreenCapture.Save("e:\\ScreenService\\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".jpg", codecInfo, parameters);
            }
        }

        //public static void GetScreen()
        //{
        //    Desktop userDesk = new Desktop();
        //    userDesk.BeginInteraction();
        //    string path = @"D:\Screen\";
        //    if (!Directory.Exists(path))
        //        Directory.CreateDirectory(path);

        //    string fileName = string.Format("SCR-{0:yyyy-MM-dd_hh-mm-ss-tt}.png", DateTime.Now);
        //    string filePath = path + fileName;
        //    bmpScreenshot = CaptureScreen.GetDesktopImage();
        //    bmpScreenshot.Save(filePath, ImageFormat.Png);
        //    userDesk.EndInteraction();
        //}

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}
