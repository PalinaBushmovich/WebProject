using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using TestWebProject.Driver;

namespace TestWebProject.Utilities
{
    public class ScreenshotMaker
    {       

        private static string NewScreenshotName
        {
            get { return "_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss-fff") + "." + ScreenshotImageFormat; }
        }
        private static ImageFormat ScreenshotImageFormat
        {
            get { return ImageFormat.Png; }
        }
        public static string TakeBrowserScreenshot(TestContext context)
        {
            var screenshotPath = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).ToString(), context.TestName + NewScreenshotName);
            var image =  Browser.GetDriver().TakeScreenshot(); 
            image.SaveAsFile(screenshotPath, OpenQA.Selenium.ScreenshotImageFormat.Png);
            return screenshotPath;
        }
        public static string TakeFullDisplayScreenshot(TestContext context)
        {
            var screenshotPath = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).ToString(), "FullScreen_" + context.TestName + NewScreenshotName);
            using (Bitmap bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bmpScreenCapture))
                {
                    g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                     Screen.PrimaryScreen.Bounds.Y,
                                     0, 0,
                                     bmpScreenCapture.Size,
                                     CopyPixelOperation.SourceCopy);
                }
                bmpScreenCapture.Save(screenshotPath, ScreenshotImageFormat);
            }
            return screenshotPath;
        }
    }
}
