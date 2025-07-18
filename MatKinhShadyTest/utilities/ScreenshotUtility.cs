using MatKinhShadyTest.Utilities.Report;
using OpenQA.Selenium;
using System;
using System.IO;

namespace MatKinhShadyTest.Utilities
{
  public class ScreenshotUtility
    : Utility
  {
    public static string TakeScreenshotAsBase64()
    {
      var img = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
      return img;
    }

    public static string TakeScreenshotToFile(string fileName)
    {
      string timestamp = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
      string destination = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "ReportResults", "Screenshots", $"{fileName}-{timestamp}.png");

      Directory.CreateDirectory(Path.GetDirectoryName(destination));

      var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
      screenshot.SaveAsFile(destination);

      ExtentReporting.LogInfo($"Screenshot is saved at: {Path.GetFullPath(destination)}");

      return destination;
    }
  }
}
